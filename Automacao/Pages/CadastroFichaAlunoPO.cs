using Microsoft.Playwright;

namespace Automacao.Pages
{
    public class CadastroFichaAlunoPO
    {
        private readonly IPage _page;
        public CadastroFichaAlunoPO(IPage page)
        {
            _page = page;
        }

        public async Task Navegue()
        {
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            await _page.GotoAsync(
                "https://regular.escolarmanageronline.com.br/escolateste/CadastroFichaAluno",
                new PageGotoOptions
                {
                    WaitUntil = WaitUntilState.NetworkIdle
                }
            );
        }


        #region CLICO NO BOTAO
        public async Task ClicoNoBotaoCadastrar()
        {
            var botao = _page.Locator("css=.botao-cadastrar");
            await botao.ClickAsync();
        }

        #endregion


        #region INFORME
        public async Task InformeNomeCivil(string civil)
        {
            var nomeCivilInput = _page.Locator("id=Nome");
            await nomeCivilInput.FillAsync(civil);
        }   

        public async Task SelecioneSexo(string sexo)
        {
            var sexoSelect = _page.Locator("id=Sexo");
            await sexoSelect.SelectOptionAsync(new SelectOptionValue { Label = sexo });
        }

        #endregion

    }
}
