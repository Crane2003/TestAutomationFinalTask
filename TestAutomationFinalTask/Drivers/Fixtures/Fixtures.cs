using TestAutomationFinalTask.Drivers.DriverAbstractFactory;

namespace TestAutomationFinalTask.Drivers.Fixtures
{
    public class FirefoxWebDriverFixture : WebDriverFixture
    {
        public FirefoxWebDriverFixture() : base(new FirefoxDriverManager())
        {
        }
    }

    public class EdgeWebDriverFixture : WebDriverFixture
    {
        public EdgeWebDriverFixture() : base(new EdgeDriverManager())
        {
        }
    }

    public class ChromeWebDriverFixture : WebDriverFixture
    {
        public ChromeWebDriverFixture() : base(new ChromeDriverManager())
        {
        }
    }


}
