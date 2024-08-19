using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFinalTask.Drivers;

[CollectionDefinition("Firefox Browser", DisableParallelization = false)]
public class FirefoxBrowserCollection : ICollectionFixture<FirefoxWebDriverFixture>
{
}
