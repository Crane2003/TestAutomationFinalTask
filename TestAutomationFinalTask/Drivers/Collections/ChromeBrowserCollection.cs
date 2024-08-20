using TestAutomationFinalTask.Drivers.Fixtures;

namespace TestAutomationFinalTask.Drivers.Collections;

[CollectionDefinition("Chrome collection", DisableParallelization = false)]
public class ChromeBrowserCollection : ICollectionFixture<ChromeWebDriverFixture>
{
}
