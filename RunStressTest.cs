using Saber.Core;
using Saber.Vendor;

namespace Saber.Vendors.StressTest
{
    public class RunStressTest : Controller, IVendorController
    {
        public override string Render(string body = "")
        {
            Theme = "dark";
            UsePlatform = true;
            var view = new View("/Vendors/StressTest/runtest.html");
            AddCSS("/editor/vendors/stresstest/runtest.css");
            AddScript("/editor/vendors/stresstest/runtest.js");
            return base.Render(view.Render());
        }
    }
}
