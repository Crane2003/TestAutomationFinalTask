using TestAutomationFinalTask.Drivers.Fixtures;

namespace TestAutomationFinalTask.Drivers.Collections;

[CollectionDefinition("Firefox collection", DisableParallelization = false)]
public class FirefoxBrowserCollection : ICollectionFixture<FirefoxWebDriverFixture>
{
}