using Microsoft.Playwright;
using Automacao.Config;

namespace Automacao.Pages.ConfigPages
{
    public abstract class BasePage
    {
        protected readonly IPage _page;
        
        // Define o caminho específico de cada página (ex: "CadastroFichaAluno")
        // Deixe vazio ("") se for a página inicial (Root)
        protected abstract string PagePath { get; }

        protected BasePage(IPage page)
        {
            _page = page;
        }

        public virtual async Task NavegarAsync()
        {
            var baseUrl = AppConfigManager.Settings.BaseUrl;
            
            // Concatena a baseUrl com o path da página (se houver)
            var fullUrl = string.IsNullOrEmpty(PagePath) 
                ? baseUrl 
                : $"{baseUrl.TrimEnd('/')}/{PagePath}";
            
            await _page.GotoAsync(fullUrl, new PageGotoOptions
            {
                WaitUntil = WaitUntilState.NetworkIdle
            });
            
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }
}
