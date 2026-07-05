Feature: Login

 
Scenario: Login com sucesso
    Given que estou na página de login
    When informo usuário 'ADMINISTRADOR' e senha '1'
    Then devo ver a página inicial