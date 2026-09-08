using System;
using System.Collections.Generic;
using System.Text;

// Importamos as Ferramentas da própria camada Application (A "Bandeja" DTO e o "Contrato" IFilmeService)
using Locadora.Application.DTOs;
using Locadora.Application.Interfaces;

// Importamos as Ferramentas do Coração (Domain). 
// Precisamos do IFilmeRepository (o contrato do Estoquista) e da classe real Filme.
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;

namespace Locadora.Application.Services
{
    // A classe 'FilmeService' está "assinando o contrato" ( : ) da 'IFilmeService'.
    // O C# agora obriga esta classe a ter os métodos ObterTodos e Adicionar.
    public class FilmeService : IFilmeService
    {
        // VARIÁVEL DE LEITURA (readonly) E PRIVADA (private)
        // O Service (Chef) precisa falar com o banco de dados, mas ele não sabe como. Ele precisa do Repository (Estoquista).
        // Criamos essa variável privada para guardar o Repository. O 'readonly' garante segurança: depois que essa variável recebe um valor, ninguém mais pode apagá-la ou alterá-la acidentalmente.
        private readonly IFilmeRepository _filmeRepository;

        // CONSTRUTOR E INJEÇÃO DE DEPENDÊNCIA (Dependency Injection)
        // Um construtor (mesmo nome da classe) é o primeiro método executado quando essa classe nasce.
        // Lembra que configuramos isso lá no Program.cs? 
        // Quando a API pede um FilmeService, o .NET automaticamente cria um FilmeRepository, injeta ele aqui dentro dos parênteses, e nós guardamos ele na nossa variável privada ali de cima.
        public FilmeService(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        // Método 1: ObterTodos
        public IEnumerable<Filme> ObterTodos()
        {
            // O Chef não sabe ir no banco de dados. Ele simplesmente pede para o Estoquista: 
            // "Me dê todos os filmes que você tem aí". E repassa a resposta para a API.
            return _filmeRepository.ObterTodos();
        }

        // Método 2: Adicionar
        public Filme Adicionar(FilmeRequestDTO filmeDto)
        {
            // O Chef pega os ingredientes da Bandeja (filmeDto) e monta o Prato Principal (a classe Filme).
            // Esse processo se chama MAPEAMENTO (Mapping). Transforma-se o DTO numa Entidade.
            var novoFilme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                PrecoDiaria = filmeDto.PrecoDiaria,
                Disponivel = filmeDto.Disponivel
            };

            // Com a Entidade montada, o Chef manda o Estoquista guardá-la no banco de dados.
            // Repare que passamos o 'novoFilme' (a Entidade), e não o DTO. O Repository não sabe o que é DTO.
            _filmeRepository.Adicionar(novoFilme);

            // Devolvemos o filme montado para a API (neste momento, o banco de dados já preencheu o ID dele automaticamente).
            return novoFilme;
        }

        public IEnumerable<Filme> AdicionarEmMassa(IEnumerable<FilmeRequestDTO> filmesDto)
        {
            // Transforma cada DTO da lista em um Filme real usando LINQ
            var filmes = filmesDto.Select(dto => new Filme
            {
                Titulo = dto.Titulo,
                Genero = dto.Genero,
                PrecoDiaria = dto.PrecoDiaria,
                Disponivel = dto.Disponivel
            }).ToList();

            // Manda a lista inteira para o Estoquista
            _filmeRepository.AdicionarEmMassa(filmes);

            return filmes;
        }

        public IEnumerable<Filme> Buscar(string? titulo, string? genero)
        {
            return _filmeRepository.Buscar(titulo, genero);
        }

        // Caso ainda não tenha o ObterPorId no Service, adicione:
        public Filme ObterPorId(int id)
        {
            return _filmeRepository.ObterPorId(id);
        }
    }
}