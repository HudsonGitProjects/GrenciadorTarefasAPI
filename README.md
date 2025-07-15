# Gerenciador de Tarefas API

#  Gerenciador de Tarefas API (.NET 8)

Sistema RESTful para gerenciamento de tarefas, projetos e histórico de alterações. Desenvolvido com .NET 8, SQL Server e Docker.

---

##  Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server 2022 (via Docker)
- xUnit + Moq (testes automatizados)
- Swagger
- Docker / Docker Compose

---

## Principais Funcionalidades (Endpoints)

- Criar, listar e excluir **projetos**
- Criar, editar e listar **tarefas dentro de projetos**
- Histórico automático de modificações nas tarefas
- Comentários em tarefas
- Regras de negócio para prioridade, remoção e limite
- Relatório de desempenho por usuário (últimos 30 dias)
- Swagger UI para documentação da API
- Testes automatizados com +80% de cobertura

---

##  Como Executar o Projeto

###  Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

###  1. Subir o banco de dados SQL Server no Docker

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=SenhaForte123!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest

2. Atualizar a base de dados
utilize o comando:

dotnet ef database update


 3. Rodar o Projeto

dotnet run

Connection String (appsettings.json)

onde tem "suaSenha" insira a senha da sua conexão do SQL server

"DefaultConnection": "Server=localhost;Database=GerenciadorTarefasDB;User Id=sa;Password=SuaSenha;TrustServerCertificate=True;"


 4. Rodar os Testes
 
 seguinte comando: 
 
 dotnet test
 
 Classes para Teste:

ProjetoServiceTests.cs

TarefaServiceTests.cs

RelatorioServiceTests.cs



#### Principais Endpoints
 
 Projetos
GET /api/projetos — Lista projetos

POST /api/projetos — Cria projeto

DELETE /api/projetos/{id} — Remove projeto (se possível)


 Tarefas
GET /api/projetos/{id}/tarefas — Lista tarefas de um projeto

POST /api/projetos/{id}/tarefas — Cria nova tarefa

PUT /api/tarefas/{id} — Atualiza tarefa

DELETE /api/tarefas/{id} — Remove tarefa


Relatórios

GET /api/relatorios/desempenho — Lista histórico de tarefas modificadas

(acesso restrito a gerentes)

 Fase 2 - Refinamento :
Tarefas poderão ser atribuídas a mais de um usuário?

Comentários podem ser editados ou apagados?

Haverá notificações por e-mail para prazos?

É necessário controle de tempo ?


 Fase 3 - Melhorias :
Autenticação e autorização com Identity + JWT

Controle de permissões baseado em papéis

Implementação de cache distribuído com Redis

Suporte a upload de anexos nas tarefas

Exportação de relatórios em PDF/Excel

CI/CD com GitHub Actions

Deploy na nuvem (Azure ou AWS)

API versioning

Autor
Hudson Dinis






