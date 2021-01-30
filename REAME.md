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
