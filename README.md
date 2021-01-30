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

### Implementando o projeto Contatos.Domain

Acessar o diretório `Contatos.Domain`

Criar o diretório `Models`


