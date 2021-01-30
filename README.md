_Repositório apenas para estudo_

# Uma arquitetura, em .Net Core, baseada nos princípios do DDD

Instrutor:

- [Jose Carlos Macoratti](http://www.macoratti.net/)

Referencias:

- http://www.macoratti.net/20/07/aspnc_ucddd1.htm

<br>
<br>
<hr>

## Anotações

A seguir vou me basear em uma arquitetura genérica para criar a aplicação e que será definida da seguinte forma:

- **Apresentação** - Cuida da interação com quem vai usar a nossa aplicação; Podemos ter aqui um projeto Web, Mobile, Web API, Desktop, etc.
- **Aplicação** - Cuida da comunicação com o Domínio; Aqui podemos ter: Classes de serviços, Interfaces, DTOs, etc.
- **Domínio** - É o coração do projeto e deve representar o negócio; Aqui teremos : entidades, Interfaces, Classes de serviços, Validações, etc.
- **Infraestrutura** - Cuida do suporte geral às demais implementações e em geral possui uma outra camada que se comunica com todas as camadas do projeto; Aqui podemos ter Repositórios, Persistência, Mapeamentos, etc.

## Anotações

### Criação dos projetos e solução

Criação da solução

```
dotnet new sln --name Contatos
```

Criar diretório `/src` e acessá-lo

```
mkdir src
cd src
```

Criar projetos/camadas

```
dotnet new classlib --name Contatos.Domain
dotnet new classlib --name Contatos.Application
dotnet new classlib --name Contatos.Infra
dotnet new webapi --name Contatos.Web
```

Incluir todos os projetos na solução

```
cd ..
dotnet sln add src/Contatos.Domain/Contatos.Domain.csproj
dotnet sln add src/Contatos.Application/Contatos.Application.csproj
dotnet sln add src/Contatos.Infra/Contatos.Infra.csproj
dotnet sln add src/Contatos.Web/Contatos.Web.csproj

dotnet restore
```

Referências:

```
dotnet add Contatos.Infra reference Contatos.Domain

dotnet add Contatos.Web reference Contatos.Domain
dotnet add Contatos.Web reference Contatos.Application

dotnet add Contatos.Application reference Contatos.Domain
dotnet add Contatos.Application reference Contatos.Infra
```

### Implementando o projeto Contatos.Domain

Acessar o diretório `Contatos.Domain`

Criar o diretório `Models` e fazer implementações

Criar o diretório `Interfaces`e fazer implementações

<hr>

### Implementando o projeto Contatos.Infra

Acessar o diretório `src`

Criar as referências:

```
dotnet add Contatos.Infra reference Contatos.Domain
```

Acessar o diretório `Contatos.Infra`

Instalar os pacotes:

```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Criar o diretório `Context`e fazer implementações

Criar o diretório `Repositories`e fazer implementações

_Obs: Não usarei o SQLServer_

<hr>

### Implementando o projeto Contatos.Web

Acessar o diretório `src`

Criar as referências:

```
dotnet add Contatos.Web reference Contatos.Domain
dotnet add Contatos.Web reference Contatos.Application
```

Acessar o diretório `Contatos.Web`

No arquivo `appsettings.json` definir a string de conexão:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Macoratti;Initial Catalog=ContatosDDD;Integrated Security=True"
  }
}
```

Criar o diretório `DTOs` e fazer implementações

Criar `ContatosController` no diretório `Controllers` e fazer implementações

<hr>

### Implementando o projeto Contatos.Application

Acessar o diretório `src`

Criar as referências:

```
dotnet add Contatos.Application reference Contatos.Domain
dotnet add Contatos.Application reference Contatos.Infra
```

Acessar o diretório `Contatos.Application`

Instalar os pacotes:

```
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
```

Criar o diretório `DI` e fazer implementações

Criar a classe `Initializer` onde usarêmos a instância de `ServiceCollection` para realizar a injeção de dependência dos serviços e também definir o provedor do banco de dados e a string de conexão.
