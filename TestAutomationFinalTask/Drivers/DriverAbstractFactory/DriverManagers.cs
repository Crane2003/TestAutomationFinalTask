using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestAutomationFinalTask.Drivers.DriverAbstractFactory
{
    public class FirefoxDriverManager : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new FirefoxDriver();
        }
    }

    public class EdgeDriverManager : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }
    }

    public class ChromeDriverManager : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }
}
