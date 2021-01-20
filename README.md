[![Gitpod ready-to-code](https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod)](https://gitpod.io/#https://github.com/marcialwushu/NETCoreAPIBoilerplate)

# NET Core API Boilerplate
:book: O projeto de estudo API com .NET Core servirá como um modelo padrão em prpjetos futuros 

#### Configuração de máquina

Para executar esse projeto na sua máquina, é necessário ter instalado nela o [.Net 5.0 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks) e o [PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads). OBS: Se o Visual Studio estiver instalado na sua máquina, é recomendado atualiza-lo ou desinstala-lo antes da instalação do SDK.



## Sumário

- [Configuração de máquina](#Configuração-de-máquina)
- [Configuração do VS Code](#Configuração-do-VS-Code)
- [Documentando a Api](#Documentando-a-Api)

#### Configuração do VS Code

##### Extensões

  - [ASP.NET Core Snippets](https://marketplace.visualstudio.com/items?itemName=rahulsahay.Csharp-ASPNETCore)
  - [Bracket Pair Colorizer](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer-2)
  - [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
  - [C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions) 
  - [C# XML Documentation](https://marketplace.visualstudio.com/items?itemName=k--kato.docomment)
  - [GitLens (Eric Amudio)](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)
  - [Path Intellisense](https://marketplace.visualstudio.com/items?itemName=christian-kohler.path-intellisense)
  - [PostgresSQL (Chris Kolkman)](https://marketplace.visualstudio.com/items?itemName=ckolkman.vscode-postgres)
  - [Visual Studio Intellicode](https://marketplace.visualstudio.com/items?itemName=VisualStudioExptTeam.vscodeintellicode)



##### Rodando o projeto

Há dois modos de rodar o projeto: 

- .Net CLI: Para rodar pelo CLI, basta abrir o terminal no VS Code e executar o comando `dotnet watch run`. 
  - Vantagem: Possui a feature de hot reload (quando o `watch` é utilizado). 
- Debugger do VS Code: basta pressionar `F5`.  
  - Vantagem: Permite o debug.
  
  
  
#### Documentando a Api

A documentação da Api é auto-gerada pelo Swagger, para complementar essa documentação, são usados os recursos de [Atributos](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#ar) e [Comentários XML](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc). O dev que irá contribuir com este projeto precisa, de regra geral, sempre usar os comentários, contendo obrigatoriamente a tag `<summary>` e usar também as devidas anotações.



##### Sumário

- [Documentação de Controllers e Actions](#Documentação-de-Controllers-e-Actions)



##### Referências

- Roteamento de atributos: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#ar
- Comentário XML: https://docs.microsoft.com/en-us/dotnet/csharp/codedoc
- Controllers: https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs#understanding-controllers
- Actions: https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs#understanding-controller-actions

- Model Binding: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0#sources
- Rotas com métodos Http: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#http-verb-templates
- Tipos de retorno de ação de controlador: https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0



##### Documentação de [Controllers](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs#understanding-controllers) e [Actions](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs#understanding-controller-actions)

Nos comentários XML, use ao menos as tags `<returns>` e `<response>`:

```c#
/// <summary>
/// Essa ação faz algo e retorna uma coisa.
/// </summary>
/// <returns>Alguma coisa</returns>
/// <response code="200">Retonar alguma coisa</response>
/// <response code="404">Alguma coisa não foi encontrada</response>
[HttpGet]
public IActionResult Action() {}
```

Coloque os atributos [[Http-MétodoHttp]](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0) e [[PoducesResponseType]](https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0) em cada ação dos controladores:

```` c#
/// <summary> ...
[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult Action() {}
````

Se a requisição tem corpo, coloque o atributo [[FromBody]](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0#sources) no parâmetro da ação:

```c#
/// <summary> ...
// Anotações ...
public IActionResult Action([FromBody] Type requestBody) {}
```

Se a requisição recebe algum valor da url, como um Id, por exemplo, use a anotação [[FromRoute]](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-5.0#sources) no parâmetro da ação e defina esse parâmetro na rota da ação:

```c#
/// <summary> ...
[HttpDelete("{Id?}")]
public IActionResult Action([FromRoute] long? Id) {}
```



Fazer o processo de subir o repo ...

Análise de tecnologias e documentações (melhores práticas; pros e cons)

- Como contribuir
  - Fork
  - PR
  - Issues
  - Padrão de commit (Conventional commit)
  - Estilização de código
  - Gitlab / Taiga.io

