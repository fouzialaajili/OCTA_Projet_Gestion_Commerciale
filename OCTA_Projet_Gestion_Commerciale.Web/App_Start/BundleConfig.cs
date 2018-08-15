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

             bundles.Add(new StyleBundle("~/infragistics/css").Include(
          "~/Content/Infragistics/css/themes/infragistics/infragistics.theme.css",
          "~/Content/Infragistics/css/structure/infragistics.css"
                ));
       /*  bundles.Add(new ScriptBundle("~/ChartOcta/js").Include("~/Scripts/ChartOcta/animatedModel.min.js", "~/Scripts/ChartOcta/jquery-3.3.1.min.js", "~/Scripts/ChartOcta/materialize.js", "~/Scripts/ChartOcta/materialize.min.js", "~/Scripts/ChartOcta/modernizr-3.6.0.min.js"));
           */
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
                        */

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                                    "~/Scripts/jquery.validate*"));
            /*
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
   //                                             */
            //         bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //"~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/infragisticsLoader").Include(
            //    "~/Script/Infragistics/js/Infragistics.loader.js"
            //    ));

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-3.0.0.min.js",
            //            "~/Scripts/jquery-ui-{version}.js",
            //            "~/Scripts/jquery-ui-i18n.js",
            //            "~/Scripts/jquery.unobtrusive-ajax.min.js",
            //            "~/Scripts/jquery.blockUI.js"
            //            ));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}