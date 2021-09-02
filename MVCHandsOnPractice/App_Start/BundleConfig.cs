using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCHandsOnPractice
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {

            //js file 
            bundles.Add(new ScriptBundle("~/bundle/js").Include("~/Content/JS/JavaScript.js"
                , "~/Content/JS/JavaScript1.js"
                , "~/Content/JS/JavaScript2.js"
                , "~/Content/JS/JavaScript3.js"
                , "~/Content/JS/JavaScript4.js"
                , "~/Content/JS/JavaScript5.js"
                , "~/Content/JS/JavaScript6.js"));

            //css file
            bundles.Add(new StyleBundle("~/bundle/CSS").IncludeDirectory("~/Content/CSS", "*.css"));

            BundleTable.EnableOptimizations = true;
        }

    }
}