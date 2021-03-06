# Oi pessoa!
Esse é um projeto de teste técnico, usando BackEnd em ASP.NET Core 2.2 (as of 2019/09) e Angular8 (as of 2019/09).

## Arquitetura
Neste projeto utilizei uma arquitetura simples, prezando separação de domínio, infraestrutura e serviços. O Backend não utiliza o Design Pattern de Repository devido ao EF Core já ser uma solução de repositório (https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/).

Ainda assim, utilizamos alguns conceitos de classes abstratas e interfaces no projeto de Service, para termos injeções de dependência na aplicação que utilizá-las (no caso, um projeto Web API).

### Domain
Este projeto contêm as classes Plain Old Csharp Object (POCO) que representam o banco de dados. Gerado através do EF Power Tools (Core).

### Infra
Configuração das classes dispostas no Domain. Contêm o EF Core e o nosso DBContext.

### Services
Utiliza o DbContext da Infra para manipular o acesso ao banco de dados. Também é responsável pelas regras de negócio da aplicação.

### WebApi
Nosso projeto de BackEnd, powered by ASP NET CORE WEB API, usando alguns conceitos:

* Auto Mapper
* Dependency Injection (default do .NET Core)
* ViewModel (em conjunto com o Mapper)

### Test
Usando o nUnit para criar alguns testes de validação na camada de serviço, usando o InMemoryDatabase do EF Core.
