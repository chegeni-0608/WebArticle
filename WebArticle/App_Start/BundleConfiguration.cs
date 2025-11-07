using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebArticle.App_Start
{
    public class BundleConfiguration
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Css").Include(
                    "~/Content/bootstrap-grid.min.css",
                    "~/Content/bootstrap-rtl.min.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/site.css"
                ));


            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                    "~/Scripts/bootstrap.bundle.js",
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/jquery.validate*"
               ));
        }
    }
}