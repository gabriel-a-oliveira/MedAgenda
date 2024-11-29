# MedAgenda

**MedAgenda** é uma API para gerenciar consultas médicas, permitindo o cadastro, leitura, atualização e exclusão (CRUD) de médicos, pacientes e consultas.

---

## Funcionalidades

- CRUD completo para entidades de **médicos**, **pacientes** e **consultas**.
- Validações para entradas no backend, garantindo a integridade dos dados.
- Gerenciamento de erros centralizado via middleware.
- Organização de responsabilidades com uso de DTOs (Data Transfer Objects).
- Suporte a migrações para gerenciamento de esquema do banco de dados.

---

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Banco de Dados:** PostgreSQL
- **ORM:** Entity Framework Core
- **API:** RESTful
- **Validações:** Data Annotations
- **Gerenciamento de Dependências:** Injeção de Dependência nativa do ASP.NET Core
- **Migrations:** Entity Framework para criação e controle do banco
- **Middleware:** Tratamento centralizado de exceções
- **Profiles:** Automapper para conversão entre entidades e DTOs

---

## Arquitetura

O projeto segue uma arquitetura **monolítica**, com **organização por camadas** para facilitar a separação de responsabilidades e a manutenção do código.  

### Estrutura do Projeto

```plaintext
MedAgenda/
├── Controllers/       # Gerencia as requisições HTTP
├── Data/              # Configurações de acesso ao banco de dados
├── DTOs/              # Objetos para entrada e saída de dados
├── ExceptionMiddleware/ # Middleware para tratamento de exceções
├── Migrations/        # Arquivos de controle do banco gerados pelo EF Core
├── Models/            # Representações das entidades do banco
├── Profiles/          # Configurações do AutoMapper
├── Services/          # Lógica de negócios
├── appsettings.json   # Configurações do projeto
├── Program.cs         # Configuração da aplicação
