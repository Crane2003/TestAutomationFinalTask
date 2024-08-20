using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers.DriverAbstractFactory;

namespace TestAutomationFinalTask.Drivers.Fixtures;

public class WebDriverFixture : IDisposable
{
    private bool _disposed;
    public IWebDriver Driver { get; private set; }

    public WebDriverFixture(IWebDriverFactory factory)
    {
        Driver = factory.CreateDriver();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Driver?.Quit();
                Driver?.Dispose();
            }

            _disposed = true;
        }
    }
}
