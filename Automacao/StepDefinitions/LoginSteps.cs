using TechTalk.SpecFlow;
using Pages;

[Binding]
public class LoginSteps
{
    private readonly LoginPage _loginPage;

    public LoginSteps(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    [Given(@"que estou na página de login")]
    public async Task GivenQueEstouNaPaginaDeLogin()
    {
        await _loginPage.Navigate();
    }

    [When(@"informo usuário '([^']*)' e senha '([^']*)'")]
    public async Task WhenInformoUsuarioESenha(string usuario, string senha)
    {
        await _loginPage.RealizarLogin(usuario, senha);
    }

    [Then(@"devo ver a página inicial")]
    public async Task ThenDevoVerAPaginaInicial()
    {
        await _loginPage.ValidarLoginComSucesso();
    }
}
