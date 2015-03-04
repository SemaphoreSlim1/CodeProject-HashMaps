using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HashMaps
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Frameworks").Include(
                        "~/Scripts/jquery-{version}.js", 
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/Knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/Home/Index").IncludeDirectory("~/Scripts/Home/Index", "*.js"));
            bundles.Add(new ScriptBundle("~/bundles/Home/Display").IncludeDirectory("~/Scripts/Home/Display", "*.js"));

            bundles.Add(new StyleBundle("~/styles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/styles/Home/Index").IncludeDirectory("~/Content/Home/Index", "*.css"));
            bundles.Add(new StyleBundle("~/styles/Home/Display").IncludeDirectory("~/Content/Home/Display", "*.css"));


            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            //BundleTable.EnableOptimizations = true;
        }
    }
}