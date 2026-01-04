Feature: Login

  Scenario: Login com sucesso
    Given que estou na página de login
    When informo usuário 'HUGOssss' e senha 'ddfsadfsadfa'
    Then devo ver a página inicial