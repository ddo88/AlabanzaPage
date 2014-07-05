using System.Web;
using System.Web.Optimization;

namespace AlabanzaPage
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery*"));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*","~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css")
                .Include("~/Content/bootstrap.yeti.css")
                .Include("~/Content/hover.css")
                );

            bundles.Add(new ScriptBundle("~/bundles/thirdparties")
                .Include("~/Scripts/underscore.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/holder.js")
                .Include("~/Scripts/bootstrap.js")
                );
            //.Include("http://imsky.github.io/holder/holder.js")
            //    .Include("//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js")

            bundles.Add(new ScriptBundle("~/bundles/knockout")
                .Include("~/Scripts/knockout-2.2.0.js")
                .Include("~/Scripts/KnockoutModel/lista_model.js")
                .Include("~/Scripts/KnockoutModel/cancion_model.js")
                .Include("~/Scripts/knockoutViewModel/lista_viewmodel.js")
                .Include("~/Scripts/knockoutViewModel/cancion_viewmodel.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}