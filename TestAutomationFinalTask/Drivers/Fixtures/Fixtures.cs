using TestAutomationFinalTask.Drivers.DriverAbstractFactory;

namespace TestAutomationFinalTask.Drivers.Fixtures
{
    public class FirefoxWebDriverFixture : WebDriverFixture
    {
        public FirefoxWebDriverFixture() : base(new FirefoxDriverFactory())
        {
        }
    }

    public class EdgeWebDriverFixture : WebDriverFixture
    {
        public EdgeWebDriverFixture() : base(new EdgeDriverFactory())
        {
        }
    }

    public class ChromeWebDriverFixture : WebDriverFixture
    {
        public ChromeWebDriverFixture() : base(new ChromeDriverFactory())
        {
        }
    }
}
