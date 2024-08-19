using OpenQA.Selenium;

namespace TestAutomationFinalTask.Drivers;

public class WebDriverFixture : IDisposable
{
    private bool _disposed;
    public IWebDriver Driver { get; private set; }

    public WebDriverFixture(string browser)
    {
        Driver = WebDriverManager.CreateDriver(browser);
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
