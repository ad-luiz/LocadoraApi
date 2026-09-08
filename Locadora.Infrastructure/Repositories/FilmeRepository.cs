// Importações padrão do sistema C#
using System;
using System.Collections.Generic;
using System.Text;

// Importa o Coração do sistema (Domain).
// Precisamos do 'IFilmeRepository' para assinar o contrato, e do 'Filme' porque o repositório trabalha com a Entidade pura.
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;

// Importa a pasta Data do próprio projeto Infrastructure.
// É aqui que mora o nosso 'AppDbContext' (a ponte com o banco de dados) que vimos no código anterior.
using Locadora.Infrastructure.Data;

namespace Locadora.Infrastructure.Repositories
{
    // A classe 'FilmeRepository' assina o contrato ( : ) 'IFilmeRepository'.
    // A partir de agora, ela é OBRIGADA a implementar os métodos ObterTodos e Adicionar exatamente como a interface mandou.
    public class FilmeRepository : IFilmeRepository
    {
        // Variável privada e somente leitura (readonly) que vai guardar a nossa conexão com o banco de dados.
        private readonly AppDbContext _context;

        // CONSTRUTOR E INJEÇÃO DE DEPENDÊNCIA
        // Quando a API precisar desse repositório, o .NET vai automaticamente criar o 'AppDbContext' (a conexão com o banco) 
        // e injetá-lo aqui dentro. Nós guardamos essa conexão na variável '_context' para usá-la nos métodos abaixo.
        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Método que implementa o ato de salvar um filme no banco de dados.
        public void Adicionar(Filme filme)
        {
            // O '_context' é o nosso banco.
            // O '.Filmes' é a tabela de filmes (o DbSet que você configurou no AppDbContext).
            // O '.Add(filme)' prepara o filme para ser inserido na tabela (mas ainda NÃO salva de verdade, fica apenas na memória).
            _context.Filmes.Add(filme);

            // O '.SaveChanges()' é quem realmente pega tudo o que estava na memória e executa o comando SQL (INSERT INTO...) no banco de dados físico.
            // É neste momento que o banco de dados gera o ID (1, 2, 3...) para o seu filme.
            _context.SaveChanges();
        }

        public void AdicionarEmMassa(IEnumerable<Filme> filmes)
        {
            _context.Filmes.AddRange(filmes);
            _context.SaveChanges();
        }

        // Método que implementa a busca de todos os filmes.
        public IEnumerable<Filme> ObterTodos()
        {
            // O '_context.Filmes' aponta para a tabela no banco.
            // O '.ToList()' executa um comando SQL (SELECT * FROM Filmes) e transforma o resultado numa lista do C# para devolvermos ao Service.
            return _context.Filmes.ToList();
        }

        public Filme ObterPorId(int id)
        {
            return _context.Filmes.Find(id)!;
        }

        public void Atualizar(Filme filme)
        {
            _context.Filmes.Update(filme);
            _context.SaveChanges();
        }

        public IEnumerable<Filme> Buscar(string? titulo, string? genero)
        {
            // Prepara a consulta sem ir ao banco ainda (AsQueryable)
            var query = _context.Filmes.AsQueryable();

            // Se o usuário digitou algum título, adiciona o "LIKE"
            if (!string.IsNullOrEmpty(titulo))
            {
                query = query.Where(f => f.Titulo.Contains(titulo));
            }

            // Se o usuário digitou algum gênero, adiciona o "LIKE"
            if (!string.IsNullOrEmpty(genero))
            {
                query = query.Where(f => f.Genero.Contains(genero));
            }

            // Agora sim, vai ao banco e traz a lista final
            return query.ToList();
        }
    }
}