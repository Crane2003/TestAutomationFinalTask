using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestAutomationFinalTask.Drivers;

public static class WebDriverManager
{
    public static IWebDriver CreateDriver(string browser)
    {
        IWebDriver driver = browser.ToLower() switch
        {
            "firefox" => new FirefoxDriver(),
            "edge" => new EdgeDriver(),
            _ => new EdgeDriver(),
        };
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        return driver;
    }
}
