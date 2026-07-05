using Automacao.Pages.ConfigPages;
using Microsoft.Playwright;

namespace Automacao.Pages.Academico.Alunos.FichaAluno
{
    public class CadastroFichaAlunoPO : BasePage
    {
        // Define o caminho específico desta página
        protected override string PagePath => "CadastroFichaAluno";

        // LOCATORS
        private ILocator BotaoCadastrar => _page.Locator("css=.botao-cadastrar");
        private ILocator NomeCivilInput => _page.Locator("id=Nome");
        private ILocator SexoSelect => _page.Locator("id=Sexo");

        public CadastroFichaAlunoPO(IPage page) : base(page)
        {
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
