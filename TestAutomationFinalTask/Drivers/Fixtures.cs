using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
