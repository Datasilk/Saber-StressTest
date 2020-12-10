using System;
using System.Linq;
using System.IO;
using System.Text.Json;
using Saber.Core;

namespace Saber.Vendors.StressTest
{
    public class StressTest : Service
    {
        public string Prepare()
        {
            if (!CheckSecurity("stress-test")) { return AccessDenied(); }
            //generate 100 random pages
            var testhtml = Cache.LoadFile(App.MapPath("/Vendors/StressTest/test.html"));
            var testjson = Cache.LoadFile(App.MapPath("/Vendors/StressTest/test.json"));
            var testlang = Cache.LoadFile(App.MapPath("/Vendors/StressTest/test_en.json"));
            var testjs = Cache.LoadFile(App.MapPath("/Vendors/StressTest/test.js"));
            for (var x = 0; x < 100; x++)
            {
                File.WriteAllText(App.MapPath("/Content/pages/test-" + x + ".html"), testhtml);
                File.WriteAllText(App.MapPath("/Content/pages/test-" + x + ".json"), testjson.Replace("{{id}}", x.ToString()));
                File.WriteAllText(App.MapPath("/Content/pages/test-" + x + "_en.json"), testlang.Replace("{{id}}", x.ToString()));
                File.WriteAllText(App.MapPath("/Content/pages/test-" + x + ".js"), testjs);
                File.WriteAllText(App.MapPath("/wwwroot/content/pages/test-" + x + ".js"), testjs);
            }
            File.WriteAllText(App.MapPath("/Vendors/StressTest/config.json"), JsonSerializer.Serialize(new Config() { Prepared = true }));
            return Success();
        }

        public string RandomTest()
        {
            var root = App.MapPath("/Content/pages/");
            var testfiles = Cache.Load("stress-test-files", delegate ()
            {
                //load list of test HTML files
                return Directory.GetFiles(App.MapPath("/Content/pages/"), "test-*.html")
                .Select(a => "/" + a.Replace(root, "").Replace("\\", "/").Replace(".html", "")).ToArray();
            });
            var rnd = new Random();
            return testfiles[rnd.Next(0, testfiles.Length - 1)];
        }

        public string Delete()
        {
            if (!CheckSecurity("stress-test")) { return AccessDenied(); }
            var root = App.MapPath("/");
            var files = Directory.GetFiles(App.MapPath("/Content/pages/"), "test-*");
            foreach(var f in files)
            {
                try
                {
                    if (f.Contains(".html"))
                    {
                        PageInfo.ClearCache("/" + f.Replace(root, "").Replace("\\", "/"), "en");
                    }
                    File.Delete(f);
                }
                catch (Exception) { }
            }
            files = Directory.GetFiles(App.MapPath("wwwroot/content/pages/"), "test-*");
            foreach (var f in files)
            {
                try
                {
                    File.Delete(f);
                }
                catch (Exception) { }
            }
            File.WriteAllText(App.MapPath("/Vendors/StressTest/config.json"), JsonSerializer.Serialize(new Config() { Prepared = false }));
            return Success();
        }
    }
}
