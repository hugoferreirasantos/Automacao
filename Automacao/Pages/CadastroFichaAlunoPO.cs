using Microsoft.Playwright;
using Automacao.Config;

namespace Automacao.Pages
{
    public class CadastroFichaAlunoPO
    {
        private readonly IPage _page;
        
        // LOCATORS
        private ILocator BotaoCadastrar => _page.Locator("css=.botao-cadastrar");
        private ILocator NomeCivilInput => _page.Locator("id=Nome");
        private ILocator SexoSelect => _page.Locator("id=Sexo");

        public CadastroFichaAlunoPO(IPage page)
        {
            _page = page;
        }

        public async Task Navegue()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var baseUrl = AppConfigManager.Settings.BaseUrl;
            await _page.GotoAsync(
                $"{baseUrl}/CadastroFichaAluno",
                new PageGotoOptions
                {
                    WaitUntil = WaitUntilState.NetworkIdle
                }
            );
        }

        #region AÇÕES
        public async Task ClicoNoBotaoCadastrar()
        {
            await BotaoCadastrar.ClickAsync();
        }

        public async Task InformeNomeCivil(string civil)
        {
            await NomeCivilInput.FillAsync(civil);
        }   

        public async Task SelecioneSexo(string sexo)
        {
            await SexoSelect.SelectOptionAsync(new SelectOptionValue { Label = sexo });
        }
        #endregion
    }
}
