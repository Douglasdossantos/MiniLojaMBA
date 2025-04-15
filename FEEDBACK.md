# Feedback - Avaliação Geral

## Front End
### Navegação

  * Pontos negativos:
    - Confusão entre camadas App e MVC

### Design
    - Será avaliado na entrega final

### Funcionalidade
    - Será avaliado na entrega final

## Back End
### Arquitetura
  * Pontos positivos:
    - Estrutura em camadas bem definidas:
      * MBA.Loja.Api
      * MBA.Loja.App
      * MBA.Loja.Business
      * MBA.Loja.Data
      * MBA.Loja.MVC

  * Pontos negativos:
    - Arquitetura excessivamente complexa com 5 camadas distintas
    - Separação desnecessária entre App e Business
    - Recomendação: Deixar o arsenal técnico para desafios que exigem complexidade, para esse case de complexidade apenas uma camada "Core" atende MVC e API

### Funcionalidade

  * Pontos negativos:
    - Configuração de Seed de dados não encontrada
    - Implementação do ASP.NET Identity não encontrada
    - Dependência exclusiva do SQL Server, sem suporte a SQLite
    - Estrutura real diferente da documentada no README

### Modelagem
  * Pontos positivos:
    - Entidades bem mapeadas

  * Pontos negativos:
    - Modelagem mais complexa que o necessário

## Projeto
### Organização
  * Pontos positivos:
    - Arquivo solution (MiniLojaMBA.sln) na raiz
    - .gitignore e .gitattributes adequados
    - Separação clara dos projetos por responsabilidade

  * Pontos negativos:
    - Falta da pasta src na raiz
    - Projetos diretamente na raiz do repositório
    - Estrutura real diferente da documentada no README

### Documentação
  * Pontos positivos:
    - README.md presente com estrutura básica
    - Arquivo FEEDBACK.md presente
    - Documentação da API via Swagger mencionada

  * Pontos negativos:
    - Documentação desatualizada em relação à estrutura real do projeto
    - Inconsistência na descrição do projeto (blog vs mini loja)
    - URLs de exemplo no README não correspondem ao repositório atual

### Instalação

  * Pontos negativos:
    - Falta de suporte a SQLite
    - Instruções de instalação não refletem a estrutura real do projeto
    - URLs de acesso incorretas no README