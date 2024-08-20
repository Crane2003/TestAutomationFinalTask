namespace TestAutomationFinalTask.Drivers
{
    public class EdgeWebDriverFixture : WebDriverFixture
    {
        public EdgeWebDriverFixture() : base("edge")
        {
        }
    }

    public class FirefoxWebDriverFixture : WebDriverFixture
    {
        public FirefoxWebDriverFixture() : base("firefox")
        {
        }
    }

    public class ChromeWebDriverFixture : WebDriverFixture
    {
        public ChromeWebDriverFixture() : base("chrome")
        {
        }
    }
}
