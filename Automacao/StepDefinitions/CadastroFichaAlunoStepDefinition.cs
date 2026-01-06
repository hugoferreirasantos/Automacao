using TechTalk.SpecFlow;
using Automacao.Pages;
using Pages;

namespace Automacao.StepDefinitions
{
    [Binding]
    public class CadastroFichaAlunoStepDefinition
    {
        private readonly CadastroFichaAlunoPO _cadastroFichaAlunoPO;
        private readonly LoginPage _login;
        public CadastroFichaAlunoStepDefinition(
    CadastroFichaAlunoPO cadastroFichaAlunoPO,
    LoginPage login)
        {
            _cadastroFichaAlunoPO = cadastroFichaAlunoPO;
            _login = login;
        }

        [Given("que desejo cadastrar a ficha do aluno")]
        [Scope(Tag = "FichaDoAluno")]
        public async Task GivenQueDesejoCadastrarAFichaDoAluno()
        {
            await _login.Navigate();
        }

        [Given("acesso o sistema utilizando operador '([^']*)'")]
        [Scope(Tag = "FichaDoAluno")]
        public async Task GivenAcessoOSistemaUtilizandoOperador(string nomeOperador)
        {
            await _login.RealizarLogin(nomeOperador, "aaaaaaaaaaaaaaaaaaaaa");
            await _cadastroFichaAlunoPO.Navegue();
        }


        [Given("clico em Cadastrar")]
        [Scope(Tag = "FichaDoAluno")]
        public async Task GivenClicoEmCadastrar()
        {
            await _cadastroFichaAlunoPO.ClicoNoBotaoCadastrar();
        }


        [Given("informo o nome civil '([^']*)'")]
        [Scope(Tag = "FichaDoAluno")]
        public async Task GivenInformoONomeCivil(string civil)
        {
            await _cadastroFichaAlunoPO.InformeNomeCivil(civil);
        }

        [Given("seleciono o sexo '([^']*)'")]
        [Scope(Tag = "FichaDoAluno")]
        public async Task GivenSelecionoOSexo(string sexo)
        {
            await _cadastroFichaAlunoPO.SelecioneSexo(sexo);
        }




    }
}
