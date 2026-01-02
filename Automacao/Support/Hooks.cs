using BoDi;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _container;
    private readonly PlaywrightDriver _driver;

    public Hooks(IObjectContainer container, PlaywrightDriver driver)
    {
        _container = container;
        _driver = driver;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        await _driver.InitializeAsync();

        // REGISTRO CRÍTICO 👇
        _container.RegisterInstanceAs(_driver.Page);
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        await _driver.DisposeAsync();
    }
}
