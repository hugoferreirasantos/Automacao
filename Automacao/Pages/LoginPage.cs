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
        public async Task Navigate()
        {
            await _page.GotoAsync(
                "https://regular.escolarmanageronline.com.br/escolateste"
            );
        }

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
