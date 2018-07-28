using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OCTA_Projet_Gestion_Commerciale.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                "~/js/bootstrap.js", "~/js/site.js"
                ));
         bundles.Add(new StyleBundle("~/bootstrap/css").Include("~/css/bootstrap.css", "~/css/site.css"
            ));
            /*bundles.Add(new ScriptBundle("~/bundles/infragisticsLoader").Include(
                "~/Script/Infragistics/js/Infragistics.loader.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.0.0.min.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-i18n.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.blockUI.js"
                        ));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                    "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquerybootstrap").Include(
                                   "~/Scripts/jquery.bootstrap.js"
                                   ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                    "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap-datepicker.fr.min.js",
            //          "~/Scripts/bootstrap-select.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                                                "~/Content/bootstrap.min.css"));
                                                */
            BundleTable.EnableOptimizations = true;


        }
    }
}