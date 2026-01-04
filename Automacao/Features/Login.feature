Feature: Login

  Scenario: Login com sucesso
    Given que estou na página de login
    When informo usuário 'HUGO QA' e senha 'TeraByte@123'
    Then devo ver a página inicial