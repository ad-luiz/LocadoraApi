// Importações básicas da linguagem C#
using System;
using System.Collections.Generic;
using System.Text;

// Importa a pasta Models, que fica dentro do próprio Domain (onde está a classe Filme original).
// Repare que NÃO tem 'using Locadora.Application' nem 'using Locadora.Infrastructure'.
// O Domain não depende de ninguém!
using Locadora.Domain.Models;

// O namespace indica que estamos no centro do sistema: projeto 'Domain', pasta 'Interfaces'.
namespace Locadora.Domain.Interfaces
{
    // 'public': Público para que o Application e o Infrastructure possam enxergar este contrato.
    // 'interface': Novamente, é um Contrato.
    // Este é o contrato do "Estoquista" (O Repositório). Ele dita as regras de como as outras camadas devem conversar com o lugar onde os dados ficam guardados.
    public interface IFilmeRepository
    {
        // Contrato 1: ObterTodos
        // Retorna uma lista (IEnumerable) de 'Filme'.
        IEnumerable<Filme> ObterTodos();

        // Contrato 2: Adicionar
        // 'void': Significa "vazio" ou "sem retorno". O método executa a ação de adicionar e não precisa devolver nenhuma resposta.
        // O detalhe mais importante aqui: Ele recebe como parâmetro a classe 'Filme' (a Entidade pura), e NÃO o FilmeRequestDTO.
        // O Repositório e o Banco de Dados não fazem ideia do que é um DTO. Eles só entendem as regras de negócio puras (Entidades).
        void Adicionar(Filme filme);
        void AdicionarEmMassa(IEnumerable<Filme> filmes);

        Filme ObterPorId(int id);
        IEnumerable<Filme> Buscar(string? genero, string? titulo);

        void Atualizar(Filme filme);
    }
}