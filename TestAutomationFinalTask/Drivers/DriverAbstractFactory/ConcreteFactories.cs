using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestAutomationFinalTask.Drivers.DriverAbstractFactory
{
    public class FirefoxDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new FirefoxDriver();
        }
    }

    public class EdgeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }
    }

    public class ChromeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }
}
