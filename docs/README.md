# **MiniLojaMBA - Aplicação de Blog Simples com MVC e API RESTful**

## **1. Apresentação**

Bem-vindo ao repositório do projeto **MiniLojaMBA**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo **Introdução ao Desenvolvimento ASP.NET Core**.
O objetivo principal desenvolver uma aplicação de blog que permite aos usuários criar, editar, visualizar e excluir posts e comentários, tanto através de uma interface web utilizando MVC quanto através de uma API RESTful.
Descreva livremente mais detalhes do seu projeto aqui.

### **Autor**
- **Douglas dos santos costa**


## **2. Proposta do Projeto**

O projeto consiste em:

- **Aplicação MVC:** Interface web para interação com o blog.
- **API RESTful:** Exposição dos recursos do blog para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Implementação de controle de acesso, diferenciando administradores e usuários comuns.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através de ORM.

## **3. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core MVC
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server/SQLite
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
  - foi disponibilizado um usuario para teste o email: teste@teste.com e a sua senha Teste@123
- **Front-end:**
  - Razor Pages/Views
  - HTML/CSS para estilização básica
- **Documentação da API:** Swagger

## **4. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:


- src/
  - MBA.Loja.App/ - Projeto MVC
  - MBA.Loja.Api/ - API RESTful
  - MBA.Loja.Business - Regras  de negocio e validações 
  - MBA.Loja.Data/ - Modelos de Dados e Configuração do EF Core
- README.md - Arquivo de Documentação do Projeto
- FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
- .gitignore - Arquivo de Ignoração do Git

## **5. Funcionalidades Implementadas**

- **CRUD para Posts e Comentários:** Permite criar, atualizar, editar e visualizar Produtos, Vendedores e categoria.
- **Autenticação e Autorização:** Diferenciação entre usuários.
- **API RESTful:** Exposição de endpoints para operações CRUD via API.
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.

## **6. Como Executar o Projeto**

### **Pré-requisitos**

- .NET SDK 8.0 ou superior
- SQL Server/SqLite
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   - `git clone https://github.com/Douglasdossantos/MiniLojaMBA.git`
   - acesso o diretório que acabou de clonar -> MiniLojaMBA, dentro dele deve existir um arquivo -> MiniLojaMBA.sln, abra o mesmos preferencialmente com o Visual studio 2022 ou superior

2. **Configuração do Banco de Dados:**
   - o projeto inicialmente deve rodar em modo de desenvolvimento junto com o SqLite, porem caso foor rodar em outro hambiente precisarar seguir outra configuração 
   - em outro modo (fora o de desenvolvimento), será preciso alterar o arquivo `appsettings.json`, configure a string de conexão do SQL Server.
   - verifique se o projeto MBA.Loja.Api e o MBA.Loja.App está configurado para inicializar juntos
   - Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos

3. **Executar a Aplicação MVC:**
   - Acesse a aplicação em: https://localhost:7111/

4. **Executar a API:**
   - Acesse a documentação da API em: https://localhost:7152/swagger/index.html

## **7. Instruções de Configuração**
- **Migrações do Banco de Dados:** As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

## **8. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

https://localhost:7152/swagger/index.html

## **9. Avaliação**

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas. 
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
