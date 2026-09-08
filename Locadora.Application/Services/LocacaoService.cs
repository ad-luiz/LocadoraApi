using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using System;

namespace Locadora.Application.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmeRepository _filmeRepository; // 1. Trazemos o Repositório de Filme

        // 2. Injetamos ele no construtor
        public LocacaoService(ILocacaoRepository locacaoRepository, IFilmeRepository filmeRepository)
        {
            _locacaoRepository = locacaoRepository;
            _filmeRepository = filmeRepository;
        }

        public Locacao Adicionar(LocacaoRequestDTO locacaoDto)
        {
            // 3. Buscamos o filme que o cliente quer alugar
            var filme = _filmeRepository.ObterPorId(locacaoDto.FilmeId);

            // 4. Verificamos se o filme existe e se está disponível!
            if (filme == null)
                throw new Exception("Filme não encontrado.");

            if (!filme.Disponivel)
                throw new Exception("Este filme já está alugado e não está disponível no momento.");

            // 5. Se passou pela verificação, mudamos o status para falso e atualizamos o banco!
            filme.Disponivel = false;
            _filmeRepository.Atualizar(filme);

            // 6. Continua a locação normalmente
            var novaLocacao = new Locacao
            {
                ClienteId = locacaoDto.ClienteId,
                FilmeId = locacaoDto.FilmeId,
                DataLocacao = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(3),
                ValorTotal = filme.PrecoDiaria * 3
            };

            _locacaoRepository.Adicionar(novaLocacao);

            return novaLocacao;
        }

        public Locacao Devolver(int locacaoId)
        {
            // 1. Busca a locação no banco
            var locacao = _locacaoRepository.ObterPorId(locacaoId);

            if (locacao == null)
                throw new Exception("Locação não encontrada.");

            if (locacao.Devolvido)
                throw new Exception("Esta locação já foi encerrada e o filme já foi devolvido.");

            // 2. Calcula a multa de atraso (Exemplo: R$ 2,00 por dia de atraso)
            if (DateTime.Now > locacao.DataDevolucao)
            {
                // Descobre quantos dias se passaram da data limite
                int diasAtraso = (DateTime.Now.Date - locacao.DataDevolucao.Date).Days;

                if (diasAtraso > 0)
                {
                    locacao.ValorTotal += (diasAtraso * 2); // Soma a multa ao valor total
                }
            }

            // 3. Encerra o contrato de locação
            locacao.Devolvido = true;
            _locacaoRepository.Atualizar(locacao);

            // 4. Devolve o filme para a prateleira (Disponível = true)
            var filme = _filmeRepository.ObterPorId(locacao.FilmeId);
            if (filme != null)
            {
                filme.Disponivel = true;
                _filmeRepository.Atualizar(filme);
            }

            return locacao;
        }

        public IEnumerable<Locacao> ObterPendentes()
        {
            return _locacaoRepository.ObterPendentes();
        }

        public IEnumerable<Locacao> ObterHistoricoPorCliente(int clienteId)
        {
            return _locacaoRepository.ObterPorClienteId(clienteId);
        }
    }
}