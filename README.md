# Bem vindo/a!
Esse é um projeto de teste técnico, usando BackEnd em ASP.NET Core 2.2 (as of 2019/09) e Angular8 (as of 2019/09).

## Arquitetura
Neste projeto utilizei uma arquitetura simples, prezando separação de domínio, infraestrutura e serviços. O Backend não utiliza o Design Pattern de Repository devido ao EF Core já ser uma solução de repositório (https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/).

Ainda assim, utilizamos alguns conceitos de classes abstratas e interfaces no projeto de Service, para termos injeções de dependência na aplicação que utilizá-las (no caso, um projeto Web API).
