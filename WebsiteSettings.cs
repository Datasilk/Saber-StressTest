using System.IO;
using System.Text.Json;
using Saber.Core;
using Saber.Vendor;

namespace Saber.Vendors.StressTest
{
    public class WebsiteSettings : IVendorWebsiteSettings
    {
        public string Name { get; set; } = "Stress Testing";
        public string Render(IRequest request)
        {
            if (!request.CheckSecurity("stress-test")) { return ""; }
            var view = new View(App.MapPath("/Vendors/StressTest/websitesettings.html"));
            var file = App.MapPath("/Vendors/StressTest/config.json");
            var prepared = false;
            if (File.Exists(file))
            {
                var config = JsonSerializer.Deserialize<Config>(File.ReadAllText(file));
                prepared = config.Prepared;
            }
            if (!prepared)
            {
                view.Show("prepare");
            }
            else
            {
                view.Show("run");
            }
            request.AddScript("/editor/vendors/stresstest/websitesettings.js");
            return view.Render();
        }
    }
}
