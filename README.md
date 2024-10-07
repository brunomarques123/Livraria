# 📚 Sistema de Gerenciamento de Biblioteca

Este projeto foi desenvolvido para otimizar o gerenciamento de uma biblioteca, permitindo o controle eficiente de livros e empréstimos, além de outras funcionalidades essenciais. Utilizei práticas modernas de desenvolvimento de software e tecnologias de ponta, com foco em escalabilidade e manutenção a longo prazo.

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core** para desenvolvimento de APIs RESTful
- **Entity Framework Core** para acesso a dados
- **CQRS** (Command Query Responsibility Segregation) para separar comandos e consultas
- **Padrão Repository** para gerenciamento da persistência
- **SQL Server** como banco de dados
- **Docker** para containerização da aplicação

## 🛠 Configuração do Projeto

### 1. Clonar o Repositório
- https://github.com/LauraAndradd/Library.git

### 2. Configurar o Ambiente
- Verifique se o .NET 8 SDK está instalado:  
   dotnet --version
- Configure o banco de dados SQL Server no arquivo appsettings.json:  
  "ConnectionStrings": {  
  "LibraryCs": "Server=SEU_SERVIDOR;Database=LibraryDb;User Id=SEU_USUARIO;Password=SUA_SENHA;"  
  }  
- Configure User Secrets (se necessário):  
  dotnet user-secrets init  
  dotnet user-secrets set "ConnectionStrings:LibraryCs" "Server=SEU_SERVIDOR;Database=LibraryDb;User Id=SEU_USUARIO;Password=SUA_SENHA;"

### 3. Rodar as Migrations  
- Aplique as migrações do Entity Framework Core para configurar o banco de dados:  
  dotnet ef database update

### 4. Rodar o Projeto
- Execute o projeto localmente:  
  dotnet run --project Library

### Docker
Se você deseja rodar a aplicação no Docker, use o seguinte comando para construir e rodar o container:  
  docker-compose up --build

## 📂 Estrutura do Projeto

- **Library.Application**: Contém a lógica de aplicação, incluindo os handlers de CQRS, validações e serviços relacionados à regra de negócio.
- **Library.Infrastructure**: Implementa os repositórios, Unit of Work, e o acesso ao banco de dados via Entity Framework Core e Dapper.
- **Library.Core**: Contém as entidades principais e contratos de domínio, interfaces dos repositórios, além de classes base e outras abstrações.
- **Library**: A API que expõe os endpoints RESTful, além de configurar a injeção de dependências, middleware e autenticação/autorização.
