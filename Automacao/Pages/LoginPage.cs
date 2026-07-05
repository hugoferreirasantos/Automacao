using Automacao.Pages.ConfigPages;
using Microsoft.Playwright;

namespace Pages
{
    public class LoginPage : BasePage
    {
        // Esta é a página inicial, então o caminho é vazio
        protected override string PagePath => "";

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
        private ILocator UsuarioInput =>
            _page.Locator("#Usuarios");

        private ILocator SenhaInput =>
            _page.Locator("#SenhaAcesso");

        private ILocator LoginButton =>
            _page.GetByRole(AriaRole.Button, new() { Name = "Entrar" });

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

            await UsuarioInput.SelectOptionAsync(
                new SelectOptionValue { Label = usuario }
            );

            await SenhaInput.FillAsync(senha);

            await LoginButton.ClickAsync();
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
