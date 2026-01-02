using Microsoft.Playwright;

namespace Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator UsuarioInput => _page.Locator("xpath=//input[@name='loginKey']");
        private ILocator SenhaInput => _page.Locator("xpath=//input[@name='password']");
        private ILocator LoginButton => _page.Locator("xpath=//div[@id='main']/div/div[2]/div/div[2]/div/div/div/div[2]/div/div[2]/form/button");
        private ILocator HomeTitle => _page.Locator("h1");

        public async Task Navigate()
        {
            await _page.GotoAsync("https://shopee.com.br/buyer/login?next=https%3A%2F%2Fshopee.com.br%2F");
        }

        public async Task RealizarLogin(string usuario, string senha)
        {
            await UsuarioInput.FillAsync(usuario);
            await _page.WaitForTimeoutAsync(1000);
            await SenhaInput.FillAsync(senha);
            await _page.WaitForTimeoutAsync(1000);
            await LoginButton.ClickAsync();
        }

        public async Task ValidarLoginComSucesso()
        {
            await Assertions.Expect(HomeTitle).ToHaveTextAsync("Home");
        }
    }
}
