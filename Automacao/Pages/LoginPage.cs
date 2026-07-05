using Automacao.Pages.ConfigPages;
using Microsoft.Playwright;

namespace Pages
{
    public class LoginPage : BasePage
    {
        // Esta é a página inicial, então o caminho é vazio
        protected override string PagePath => "Login";

        public LoginPage(IPage page) : base(page)
        {
        }

        // =========================
        // Variáveis
        // =========================
        public string NomeUsuario { get; private set; }

        // =========================
        // LOCATORS - LOGIN
        // =========================
        

        // =========================
        // LOCATORS - HOME (IFRAME)
        // =========================
        private IFrameLocator HomeFrame =>
            _page.FrameLocator("iframe");

        private ILocator HomeTitle =>
            HomeFrame.Locator(".tela-inicial-saudacao");

        // =========================
        // AÇÕES
        // =========================
        public async Task RealizarLogin(string usuario, string senha)
        {
            NomeUsuario = usuario;

            // Abre o combo de usuários
            await _page.Locator("#Usuarios-text").ClickAsync();

            // Seleciona o usuário pelo texto
            await _page
                .Locator("#Usuarios-options .ns-login-select-option")
                .Filter(new() { HasText = usuario })
                .ClickAsync();

            // Preenche a senha
            await _page.Locator("#SenhaAcesso").FillAsync(senha);

            // Efetua o login
            await _page.Locator("#btnEntrar").ClickAsync();

            // Aguarda o redirecionamento após o login
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        // =========================
        // VALIDAÇÃO
        // =========================
        public async Task ValidarLoginComSucesso()
        {
            // Aguarda a saudação aparecer dentro do iframe
            await Assertions.Expect(HomeTitle)
                .ToBeVisibleAsync(new() { Timeout = 20000 });

            // Valida apenas o nome (mais robusto)
            await Assertions.Expect(HomeTitle)
                .ToContainTextAsync(NomeUsuario);

            await _page.WaitForTimeoutAsync(1000);
        }
    }
}
