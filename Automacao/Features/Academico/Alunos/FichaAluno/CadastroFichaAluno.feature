Feature: Cadastrar Ficha do Aluno 

@Academico
@FichaDoAluno
@CadastrarFichaDoAluno
Scenario: Cadastrar ficha do aluno com informacoes obrigatorias
	Given que desejo cadastrar a ficha do aluno
	And acesso o sistema utilizando operador 'ADMINISTRADOR'
	And clico em Cadastrar
	And informo o nome civil 'civil'
	And seleciono o sexo 'Masculino'
	And informo a Nascionalidade '<nacionalidade>'
	And informo a data de nascimento '<dataNascimento>'
	And seleciono a naturalidade '<naturalidade>'
	And clico em Endereco e telefone
	And informo o CEP '<cep>'
	And clico em Documentos
	And informo o CPF '<cpf>'
	When clico em Gravar
	Then o sistema apresenta a mensagem 'Cadastro realizado, deseja ir para a tela de matrícula?'
	And clico em Não