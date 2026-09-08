# 🎬 Locadora API

API REST desenvolvida em **C# com ASP.NET Core** para gerenciamento de uma locadora de filmes.

O projeto foi desenvolvido com o objetivo de praticar e demonstrar conceitos de desenvolvimento de APIs REST, persistência de dados, **Entity Framework Core**, **SQL Server**, DTOs, validações, relacionamentos entre entidades, operações CRUD e implementação de regras de negócio.

---

## 🚀 Tecnologias

* **C#**
* **ASP.NET Core**
* **Entity Framework Core**
* **SQL Server**
* **Swagger / OpenAPI**
* **Visual Studio**

---

## ⚙️ Funcionalidades

### 👤 Clientes

* Cadastro de clientes.
* Consulta de clientes.
* Consulta de cliente por ID.
* Atualização de clientes.
* Exclusão de clientes.
* Busca de clientes.
* Cadastro de clientes em massa.

### 🎬 Filmes

* Cadastro de filmes.
* Consulta de filmes.
* Consulta de filme por ID.
* Busca de filmes.
* Cadastro de filmes em massa.

### 📋 Locações

* Registro de locações.
* Registro de devoluções.
* Consulta de locações pendentes.
* Consulta de locações por cliente.

---

## 🏗️ Estrutura do projeto

O projeto utiliza uma organização baseada na separação de responsabilidades, facilitando a manutenção e evolução da aplicação.

```text
LocadoraApi/
│
├── Controllers/
│   ├── ClienteController.cs
│   ├── FilmeController.cs
│   └── LocacaoController.cs
│
├── DTOs/
│   ├── ClienteRequestDTO.cs
│   ├── FilmeRequestDTO.cs
│   └── LocacaoRequestDTO.cs
│
├── Models/
│   ├── Cliente.cs
│   ├── Filme.cs
│   └── Locacao.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Migrations/
│
├── Program.cs
├── appsettings.json
├── LocadoraApi.csproj
└── README.md
```

> A estrutura pode sofrer alterações conforme a evolução do projeto.

---

# 📌 Endpoints

## 👤 Clientes

| Método   | Endpoint                | Descrição                   |
| -------- | ----------------------- | --------------------------- |
| `GET`    | `/api/Cliente`          | Lista todos os clientes     |
| `POST`   | `/api/Cliente`          | Cadastra um novo cliente    |
| `GET`    | `/api/Cliente/{id}`     | Consulta um cliente pelo ID |
| `PUT`    | `/api/Cliente/{id}`     | Atualiza um cliente         |
| `DELETE` | `/api/Cliente/{id}`     | Remove um cliente           |
| `GET`    | `/api/Cliente/buscar`   | Busca clientes              |
| `POST`   | `/api/Cliente/em-massa` | Cadastra múltiplos clientes |

---

## 🎬 Filmes

| Método | Endpoint              | Descrição                 |
| ------ | --------------------- | ------------------------- |
| `GET`  | `/api/Filme`          | Lista todos os filmes     |
| `POST` | `/api/Filme`          | Cadastra um novo filme    |
| `GET`  | `/api/Filme/{id}`     | Consulta um filme pelo ID |
| `GET`  | `/api/Filme/buscar`   | Busca filmes              |
| `POST` | `/api/Filme/em-massa` | Cadastra múltiplos filmes |

---

## 📋 Locações

| Método | Endpoint                           | Descrição                           |
| ------ | ---------------------------------- | ----------------------------------- |
| `POST` | `/api/Locacao`                     | Registra uma nova locação           |
| `PUT`  | `/api/Locacao/devolver/{id}`       | Registra a devolução de uma locação |
| `GET`  | `/api/Locacao/pendentes`           | Lista as locações pendentes         |
| `GET`  | `/api/Locacao/cliente/{clienteId}` | Lista as locações de um cliente     |

---

# 📦 DTOs

A API utiliza DTOs (**Data Transfer Objects**) para controlar os dados recebidos pelas requisições.

### `ClienteRequestDTO`

Utilizado para receber os dados necessários para cadastro ou operação relacionada a clientes.

### `FilmeRequestDTO`

Utilizado para receber os dados necessários para cadastro de filmes.

### `LocacaoRequestDTO`

Utilizado para receber os dados necessários para registrar uma locação.

---

# 📝 Exemplo de requisição

## Cadastro de filme

**POST**

```text
/api/Filme
```

Exemplo de JSON:

```json
{
  "titulo": "O Poderoso Chefão",
  "genero": "Drama",
  "anoLancamento": 1972
}
```

---

## Cadastro de cliente

**POST**

```text
/api/Cliente
```

Exemplo:

```json
{
  "nome": "João da Silva",
  "email": "joao@email.com"
}
```

> Os campos apresentados nos exemplos devem corresponder aos DTOs implementados atualmente na API.

---

# 🗄️ Banco de dados

A aplicação utiliza **SQL Server** como banco de dados e **Entity Framework Core** para mapeamento objeto-relacional (ORM).

As alterações na estrutura do banco são controladas através de **Migrations**.

A aplicação utiliza uma connection string configurada no arquivo:

```text
appsettings.json
```

Exemplo de configuração local:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=LocadoraDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> A configuração acima utiliza autenticação do Windows para uma instalação local do SQL Server Express.

---

# 🛠️ Como executar o projeto localmente

## Pré-requisitos

Antes de executar a aplicação, é necessário ter instalado:

* [.NET SDK](https://dotnet.microsoft.com/)
* [Visual Studio](https://visualstudio.microsoft.com/)
* SQL Server ou SQL Server Express
* Git

---

## 1. Clonar o repositório

```bash
git clone https://github.com/ad-luiz/Locadoraaapi.git
```

Entrar na pasta do projeto:

```bash
cd Locadoraaapi
```

---

## 2. Abrir o projeto

Abra a solução/projeto no **Visual Studio**.

---

## 3. Configurar o banco de dados

Verifique a connection string no arquivo:

```text
appsettings.json
```

Caso necessário, altere a configuração de acordo com o SQL Server instalado na máquina.

---

## 4. Executar as migrations

No **Package Manager Console** do Visual Studio:

```powershell
Update-Database
```

Ou utilizando o .NET CLI:

```bash
dotnet ef database update
```

Esse procedimento cria/atualiza a estrutura do banco de dados conforme as migrations disponíveis no projeto.

---

## 5. Executar a aplicação

Utilizando o Visual Studio, execute o projeto normalmente.

Ou pelo terminal:

```bash
dotnet run
```

---

# 📖 Swagger / OpenAPI

A API utiliza **Swagger / OpenAPI** para documentação e testes dos endpoints.

Após iniciar a aplicação, acesse a interface do Swagger disponibilizada pela aplicação para visualizar:

* Endpoints disponíveis.
* Métodos HTTP.
* Parâmetros.
* Schemas.
* Dados de entrada.
* Respostas da API.

O Swagger também permite realizar requisições diretamente pela interface.

---

# 🧠 Conceitos aplicados

Este projeto foi desenvolvido para praticar conceitos importantes do desenvolvimento backend com .NET:

* Desenvolvimento de APIs REST.
* C#.
* ASP.NET Core.
* Entity Framework Core.
* SQL Server.
* Entity Framework Migrations.
* Operações CRUD.
* DTOs.
* Injeção de Dependência.
* Validação de dados.
* Relacionamentos entre entidades.
* Regras de negócio.
* HTTP Methods.
* HTTP Status Codes.
* Swagger / OpenAPI.
* Persistência de dados.
* Separação de responsabilidades.
* Manipulação de requisições e respostas HTTP.
* Cadastro de dados em massa.

---

# 🔄 Fluxo básico da aplicação

O fluxo principal da aplicação pode ser representado da seguinte forma:

```text
Cliente
   │
   ▼
API REST
   │
   ├── Cliente
   │
   ├── Filme
   │
   └── Locação
          │
          ▼
   Entity Framework Core
          │
          ▼
      SQL Server
```

---

# 🔮 Próximos passos

Possíveis evoluções para versões futuras do projeto:

* [ ] Implementação de autenticação com JWT.
* [ ] Controle de autorização por perfil de usuário.
* [ ] Testes unitários.
* [ ] Testes de integração.
* [ ] Tratamento global de exceções.
* [ ] Implementação de logging.
* [ ] Paginação de resultados.
* [ ] Filtros e ordenação.
* [ ] Dockerização da aplicação.
* [ ] Implementação de CI/CD.
* [ ] Deploy da API em ambiente de nuvem.

---

# 📌 Status

🚧 **Em desenvolvimento**

O projeto está sendo desenvolvido como parte do processo de aprendizado e evolução em **desenvolvimento backend com C# e .NET**.

---

# 👨‍💻 Autor

**Adolfo Soares**

Projeto desenvolvido para fins de **estudo, prática e portfólio profissional**, com foco no desenvolvimento de APIs utilizando **C#, ASP.NET Core, Entity Framework Core e SQL Server**.
