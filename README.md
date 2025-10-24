# Cadastro de Pets
![C#](https://img.shields.io/badge/C%23-13-blue.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet.svg)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-blueviolet.svg)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-orange.svg)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red.svg)

Este projeto é uma API RESTful para um sistema de cadastro de animais de estimação (pets), desenvolvida como forma de aplicar e consolidar conhecimentos no ecossistema .NET.

A API permite realizar todas as operações CRUD (Create, Read, Update, Delete) para gerenciar os pets, utilizando uma arquitetura limpa e robusta. O projeto foi construído usando o template ASP.NET Core Web API e utiliza o Swagger/OpenAPI para documentação e testes dos endpoints.

## 🚀 Tecnologias Utilizadas

Este projeto foi construído com as seguintes tecnologias:

* **[C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)**: Linguagem de programação principal.
* **[.NET (ASP.NET Core)](https://dotnet.microsoft.com/pt-br/apps/aspnet)**: Framework para a construção da Web API.
* **[Entity Framework Core (EF Core)](https://learn.microsoft.com/pt-br/ef/)**: ORM (Object-Relational Mapper) utilizado para a comunicação com o banco de dados de forma eficiente.
* **[SQL Server](https://www.microsoft.com/pt-br/sql-server)**: O SGBD (Sistema Gerenciador de Banco de Dados) relacional onde os dados são armazenados.
* **[Swagger (OpenAPI)](https://swagger.io/)**: Ferramenta utilizada para documentar e testar os endpoints da API de forma interativa.

## ✨ Funcionalidades (Endpoints da API)

A API expõe os seguintes métodos para o gerenciamento dos pets:

### `[POST] /api/Pets`
* **Descrição:** Adiciona um novo pet ao banco de dados.
* **Corpo da Requisição:** Um objeto JSON com os dados do pet (Nome, Especie, Sexo, Idade, Peso, Raca).
* **Validação:** Utiliza Data Annotations para validar os dados de entrada (ex: campos obrigatórios, formato do sexo `M/F`, range de idade).

### `[GET] /api/Pets`
* **Descrição:** Retorna a lista completa de todos os pets cadastrados.

### `[GET] /api/Pets/{id}`
* **Descrição:** Busca e retorna um pet específico pelo seu `Id` (chave primária).
* **Parâmetro:** `id` (int) - O ID do pet a ser buscado.

### `[GET] /api/Pets/ObterPorNome`
* **Descrição:** Busca e retorna um pet específico pelo seu `Nome`.
* **Parâmetro (Query):** `name` (string) - O nome do pet a ser buscado (a busca não diferencia maiúsculas de minúsculas).

### `[PUT] /api/Pets/{id}`
* **Descrição:** Atualiza os dados de um pet existente.
* **Parâmetro:** `id` (int) - O ID do pet a ser atualizado.
* **Corpo da Requisição:** Um objeto JSON com os dados *completos* do pet a serem modificados.

### `[DELETE] /api/Pets/{id}`
* **Descrição:** Remove um pet do banco de dados.
* **Parâmetro:** `id` (int) - O ID do pet a ser deletado.

## 🖼️ Imagens do Swagger e do SQL Server
<img width="1902" height="941" alt="image" src="https://github.com/user-attachments/assets/5ec7869d-b670-4a94-b5d4-f635d20c70c3" />
<img width="1564" height="714" alt="image" src="https://github.com/user-attachments/assets/b15a20ce-95d1-472d-bf2c-f4d65318cb0e" />


## ⚙️ Como Executar o Projeto

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/JoaoPaulo-Costa01/Cadastro-de-Pets
    cd ProjetoPets 
    ```

2.  **Configure o Banco de Dados:**
    * Abra o arquivo `appsettings.json`.
    * Modifique a string de conexão (`DefaultConnection` ou similar) para apontar para o seu servidor SQL Server local ou remoto.

3.  **Aplique as Migrações (Entity Framework):**
    * Abra o terminal na raiz do projeto (ou use o *Package Manager Console* no Visual Studio).
    * Execute o comando para criar/atualizar o banco de dados com base nas Models:
    ```bash
    dotnet ef database update
    ```
    *(Caso não tenha o `dotnet-ef` instalado, instale com: `dotnet tool install --global dotnet-ef`)*

4.  **Execute a Aplicação:**
    * Pelo Visual Studio: Pressione `F5` ou o botão "Play".
    * Pelo terminal:
    ```bash
    dotnet run
    ```

5.  **Teste no Swagger:**
    * Após a execução, o navegador será aberto automaticamente na interface do Swagger (geralmente em `http://localhost:XXXX/swagger`).
    * Você pode usar essa interface para testar todos os endpoints listados acima.
