# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC implementado com rotas funcionais e páginas de login e algumas visualizações.
    - Estrutura básica da navegação está funcional.

### Design
  - Interface administrativa funcional, mas básica.

### Funcionalidade
  * Pontos positivos:
    - CRUD implementado na API para produtos e categorias.
    - Autenticação com ASP.NET Identity nas camadas MVC e API.
    - Migrations automáticas, seed de dados e SQLite corretamente configurados.
    - Registro de usuário e vendedor modelado, embora mal implementado.

  * Pontos negativos:
    - O vendedor não é criado automaticamente no momento do registro do usuário (ID compartilhado).
    - A criação e atualização de produtos não valida se o vendedor autenticado está operando sobre seus próprios produtos.
    - O ID do vendedor é recebido por formulário, o que pode comprometer a integridade dos dados e abre margem para alteração indevida de registros.

## Back End

### Arquitetura
  * Pontos positivos:
    - Separação clara entre camadas (API, App, Business, Data).

  * Pontos negativos:
    - As camadas `Business` e `Data` poderiam estar unificadas em uma camada `Core`, conforme simplicidade exigida no escopo.
    - Redundância de lógica de seed: soluções distintas usadas para API e MVC, quando poderiam ser reutilizadas em uma única classe.

### Funcionalidade
  * Pontos positivos:
    - Autenticação com JWT na API e cookies no MVC funcional.
    - Operações básicas da API funcionam.

  * Pontos negativos:
    - CRUD incompleto na camada MVC.
    - Segurança de controle de propriedade dos dados (vendedor-produto) não implementada.

### Modelagem
  * Pontos positivos:
    - Entidades bem definidas, aderentes ao domínio.
    - Separação de models e viewmodels básica está presente.

  * Pontos negativos:
    - Nenhum ponto grave além da modelagem incompleta entre usuário, vendedor e produto.

## Projeto

### Organização
  * Pontos positivos:
    - Projeto organizado em `src`, com solution `.sln` na raiz.
    - Boa estrutura de pastas e arquivos.

### Documentação
  * Pontos positivos:
    - Swagger ativo na API.

### Instalação
  * Pontos positivos:
    - SQLite corretamente configurado.
    - Migrations automáticas e seed no startup da aplicação.

  * Pontos negativos:
    - Duplicidade no processo de seed entre projetos.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 6        | 1,8                                      |
| **Qualidade do Código**       | 20%      | 7        | 1,4                                      |
| **Eficiência e Desempenho**   | 20%      | 7        | 1,4                                      |
| **Inovação e Diferenciais**   | 10%      | 8        | 0,8                                      |
| **Documentação e Organização**| 10%      | 9        | 0,9                                      |
| **Resolução de Feedbacks**    | 10%      | 7        | 0,7                                      |
| **Total**                     | 100%     | -        | **7,0**                                  |

## 🎯 **Nota Final: 7 / 10**
