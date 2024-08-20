namespace TestAutomationFinalTask.Drivers;

[CollectionDefinition("Chrome collection", DisableParallelization = false)]
public class ChromeBrowserCollection : ICollectionFixture<ChromeWebDriverFixture>
{
}
