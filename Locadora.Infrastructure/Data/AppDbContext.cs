// Importa as nossas Entidades puras (Filme, Cliente, Locacao) que criamos no Coração do sistema (Domain).
using Locadora.Domain.Models;

// Importa a biblioteca do Entity Framework Core. 
// O EF Core é um ORM (Object-Relational Mapper). Ele é um "tradutor" que transforma os seus comandos C# (como .Add() ou .ToList()) em comandos SQL (como INSERT INTO ou SELECT *) automaticamente.
using Microsoft.EntityFrameworkCore;

// O namespace confirma que estamos na camada 'Infrastructure', dentro da pasta 'Data' (Dados).
// É APENAS esta camada que tem permissão para instalar e usar o Entity Framework.
namespace Locadora.Infrastructure.Data
{
    // A nossa classe 'AppDbContext' herda ( : ) de 'DbContext'.
    // 'DbContext' é uma classe mãe que já vem pronta dentro do Entity Framework. Ao herdar dela, a nossa classe ganha superpoderes para conversar com o banco de dados.
    public class AppDbContext : DbContext
    {
        // CONSTRUTOR
        // Este construtor recebe um pacote de configurações (options). 
        // A principal configuração que vem aqui dentro é a "Connection String" (o endereço e a senha de onde o seu banco de dados SQL Server/SQLite está rodando).
        // A instrução ': base(options)' apenas pega esse pacote e repassa para a classe mãe (DbContext) fazer o trabalho pesado de se conectar.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DBSETS (Tabelas do Banco de Dados)
        // Cada 'DbSet' representa exatamente UMA TABELA no seu banco de dados.
        // Quando você diz 'DbSet<Filme>', o Entity Framework lê a sua classe 'Filme' e cria uma tabela chamada "Filmes", usando as propriedades da classe (Id, Titulo, Genero) como as colunas da tabela.
        public DbSet<Filme> Filmes { get; set; }

        // Cria e gerencia a tabela "Clientes" no banco de dados.
        public DbSet<Cliente> Clientes { get; set; }

        // Cria e gerencia a tabela "Locacoes" no banco de dados.
        public DbSet<Locacao> Locacoes { get; set; }

        // ADICIONE ESTE MÉTODO PARA CONFIGURAR AS CASAS DECIMAIS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Diz ao banco: "O PrecoDiaria do Filme terá até 18 números totais, sendo 2 após a vírgula"
            modelBuilder.Entity<Filme>()
                .Property(f => f.PrecoDiaria)
                .HasPrecision(18, 2);

            // O mesmo para o ValorTotal da Locação
            modelBuilder.Entity<Locacao>()
                .Property(l => l.ValorTotal)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}