// Importações das nossas camadas e do Entity Framework, necessárias para o Gerente conhecer o sistema todo.
using Locadora.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Locadora.Application.Interfaces;
using Locadora.Application.Services;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Repositories;

// ---------------------------------------------------------
// PARTE 1: O "BUILDER" (Preparando os ingredientes e serviços)
// ---------------------------------------------------------

// Cria o "Construtor" da aplicação. É ele quem gerencia os serviços e as configurações antes da API "nascer".
var builder = WebApplication.CreateBuilder(args);

// INJEÇÃO DE DEPENDÊNCIA (Dependency Injection)
// O '.AddScoped' ensina o .NET quem ele deve chamar.
// O "Scoped" (Escopo) significa que a cada vez que o usuário acessar a API (uma requisição HTTP), 
// o .NET cria uma nova cópia do Repository e do Service. Quando a requisição termina, ele destrói essas cópias para liberar memória.
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IFilmeService, FilmeService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
builder.Services.AddScoped<ILocacaoService, LocacaoService>();

// Prepara a API para reconhecer as rotas e gerar a documentação visual (o nosso famoso Swagger!).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONFIGURAÇÃO DO BANCO DE DADOS
// Registra o nosso 'AppDbContext' (a ponte do banco) no contêiner de serviços.
// O 'options.UseSqlServer' avisa o Entity Framework que estamos usando o banco da Microsoft (SQL Server).
// O 'GetConnectionString' vai lá no arquivo de texto 'appsettings.json' e pega a senha e o endereço do banco sob o nome "DefaultConnection".
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Diz para o construtor: "Procure por todas as classes que terminam com 'Controller' e as ative".
builder.Services.AddControllers();

// (Linha comentada padrão da Microsoft para o novo modelo de documentação OpenAPI, que não estamos usando no momento).
// builder.Services.AddOpenApi();

// O "Build" é o divisor de águas. Aqui, a fase de preparação acaba e a API "nasce" fisicamente.
var app = builder.Build();


// ---------------------------------------------------------
// PARTE 2: O "APP" (Configurando a esteira/pipeline HTTP)
// ---------------------------------------------------------

// O '.IsDevelopment()' verifica se estamos rodando o código na nossa máquina (Desenvolvimento).
// Se fôssemos publicar isso num servidor real na nuvem (Produção), ele não entraria neste 'if', 
// escondendo o Swagger para que clientes reais não fiquem fuçando no nosso banco de dados.
if (app.Environment.IsDevelopment())
{
    // Habilita a geração do arquivo JSON do Swagger e a interface gráfica (aquela tela verde bonita que testamos).
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Lembra dessa linha? Nós a comentamos de propósito! 
// Ela forçava o redirecionamento de HTTP para HTTPS (seguro), o que estava causando aquele erro 
// de "Failed to fetch / CORS" quando tentávamos testar pelo Swagger localmente.
//app.UseHttpsRedirection();

// Habilita o sistema de autorização (para o caso de implementarmos login com token no futuro).
app.UseAuthorization();

// Mapeia os controladores. É isso que permite que o navegador encontre rotas como '/api/Filme'.
app.MapControllers();

// Liga o motor. O 'Run' faz a tela preta ficar aberta, escutando as portas (ex: http://localhost:5055) indefinidamente.
app.Run();