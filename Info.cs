using Saber.Vendor;
namespace Saber.Vendors.StressTest
{
    public class Info : IVendorInfo
    {
        public string Key { get; set; } = "StressTest";
        public string Name { get; set; } = "Stress Test";
        public string Description { get; set; } = "Allows administrators to stress test their web server by loading 24 iframes that rapidly load random test pages from their website.";
        public Version Version { get; set; } = "1.0.0.0";
    }
}
