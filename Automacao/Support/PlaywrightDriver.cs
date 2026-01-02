using Microsoft.Playwright;

public class PlaywrightDriver
{
    public IPage Page { get; private set; }
    private IBrowser _browser;
    private IPlaywright _playwright;

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();

        _browser = await _playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions { Headless = false });

        var context = await _browser.NewContextAsync();
        Page = await context.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}
