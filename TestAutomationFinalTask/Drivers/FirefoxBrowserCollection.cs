namespace TestAutomationFinalTask.Drivers;

[CollectionDefinition("Firefox collection", DisableParallelization = false)]
public class FirefoxBrowserCollection : ICollectionFixture<FirefoxWebDriverFixture>
{
}