Feature: Login

  Scenario: Login com sucesso
    Given que estou na página de login
    When informo usuário 'admin' e senha '123456'
    Then devo ver a página inicial