# 🎬 Locadora API

API REST desenvolvida em **C# com ASP.NET Core** para gerenciamento de uma locadora de filmes.

O projeto tem como objetivo aplicar conceitos de desenvolvimento de APIs REST, persistência de dados, Entity Framework Core, relacionamentos entre entidades, DTOs, validações e operações CRUD.

## 🚀 Tecnologias

* C#
* ASP.NET Core
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI
* Visual Studio

## ⚙️ Funcionalidades

* Cadastro, consulta, atualização e exclusão de clientes.
* Cadastro e gerenciamento do catálogo de filmes.
* Gerenciamento de locações.
* Controle de devoluções.
* Cálculo de prazos de locação.
* Persistência de dados utilizando SQL Server.
* Documentação e testes dos endpoints através do Swagger.

## 🏗️ Estrutura do projeto

O projeto utiliza uma estrutura organizada para separar as responsabilidades da aplicação:

* **Controllers** — responsáveis pelos endpoints da API.
* **Models/Entities** — representam as entidades do sistema.
* **DTOs** — utilizados para entrada e saída de dados da API.
* **Services** — concentram as regras de negócio.
* **Data** — configuração do banco de dados e Entity Framework Core.
* **Migrations** — controle das alterações do banco de dados.

## 📌 Principais endpoints

### Clientes

| Método | Endpoint             | Descrição               |
| ------ | -------------------- | ----------------------- |
| GET    | `/api/clientes`      | Lista todos os clientes |
| GET    | `/api/clientes/{id}` | Consulta um cliente     |
| POST   | `/api/clientes`      | Cadastra um cliente     |
| PUT    | `/api/clientes/{id}` | Atualiza um cliente     |
| DELETE | `/api/clientes/{id}` | Remove um cliente       |

### Filmes

| Método | Endpoint           | Descrição         |
| ------ | ------------------ | ----------------- |
| GET    | `/api/filmes`      | Lista os filmes   |
| GET    | `/api/filmes/{id}` | Consulta um filme |
| POST   | `/api/filmes`      | Cadastra um filme |
| PUT    | `/api/filmes/{id}` | Atualiza um filme |
| DELETE | `/api/filmes/{id}` | Remove um filme   |

### Locações

| Método | Endpoint                       | Descrição            |
| ------ | ------------------------------ | -------------------- |
| GET    | `/api/locacoes`                | Lista as locações    |
| POST   | `/api/locacoes`                | Registra uma locação |
| PUT    | `/api/locacoes/{id}/devolucao` | Registra a devolução |

> Os endpoints podem variar conforme a implementação atual do projeto.

## 📝 Exemplo de requisição

### Cadastro de filme

```json
{
  "titulo": "O Poderoso Chefão",
  "genero": "Drama",
  "anoLancamento": 1972
}
```

## 🛠️ Como executar localmente

### 1. Clone o repositório

```bash
git clone https://github.com/ad-luiz/Locadoraaapi.git
```

### 2. Abra o projeto

Abra a solução no **Visual Studio**.

### 3. Configure o banco de dados

Configure a string de conexão do **SQL Server** no arquivo:

```text
appsettings.json
```

### 4. Execute as migrations

No Package Manager Console:

```powershell
Update-Database
```

Ou utilizando o .NET CLI:

```bash
dotnet ef database update
```

### 5. Execute a aplicação

```bash
dotnet run
```

Após iniciar a aplicação, acesse o **Swagger** para visualizar e testar os endpoints disponíveis.

## 📚 Conceitos aplicados

Este projeto foi desenvolvido para praticar:

* Desenvolvimento de APIs REST
* ASP.NET Core
* C#
* Entity Framework Core
* Entity Framework Migrations
* SQL Server
* CRUD
* DTOs
* Injeção de Dependência
* Validação de dados
* Relacionamentos entre entidades
* HTTP Status Codes
* Swagger / OpenAPI
* Separação de responsabilidades
* Regras de negócio

## 🔮 Próximos passos

Possíveis evoluções do projeto:

* Implementação de autenticação com JWT.
* Controle de autorização por perfil de usuário.
* Testes unitários e de integração.
* Tratamento global de exceções.
* Implementação de logging.
* Paginação e filtros.
* Dockerização da aplicação.
* Implementação de CI/CD.

## 📌 Status

🚧 **Em desenvolvimento**

## 👨‍💻 Autor

**Adolfo Soares**

Projeto desenvolvido para fins de estudo e portfólio profissional.
