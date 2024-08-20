using TestAutomationFinalTask.Drivers.Fixtures;

namespace TestAutomationFinalTask.Drivers.Collections;

[CollectionDefinition("Edge collection", DisableParallelization = false)]
public class EdgeBrowserCollection : ICollectionFixture<EdgeWebDriverFixture>
{
}
