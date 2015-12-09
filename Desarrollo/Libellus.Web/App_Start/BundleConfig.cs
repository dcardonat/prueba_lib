namespace Libellus.Web
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/content/css").Include(
                "~/Content/font-openSansCondensed.css",
                "~/Content/font-oswald.css",
                "~/Content/bootstrap.min.css",
                "~/Content/admin.css",
                "~/Content/Site.css",
                "~/Content/PagedList.css",
                "~/Content/jquery-ui/jquery-ui.css",
                "~/Content/jquery-ui/jquery-ui.structure.min.css",
                "~/Content/jquery-ui/jquery-ui.theme.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/general/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/libellus.js",
                "~/Scripts/Spin/spin.js"));

            bundles.Add(new ScriptBundle("~/bundles/JQuery/js").Include(
               "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/libellus.custom-validations.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerycookies").Include(
                "~/Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/js/select2").Include(
                      "~/Scripts/Select2/select2.js",
                      "~/Scripts/Select2/select2_locale_es.js"));

            bundles.Add(new ScriptBundle("~/js/jquery-ui").Include(
                      "~/Scripts/jqueryPlugins/jquery-ui/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/js/jstree").Include(
                      "~/Scripts/jqueryPlugins/jstree/dist/jstree.min.js"));

            bundles.Add(new StyleBundle("~/css/select2").Include(
                      "~/Content/Select2/select2.css",
                      "~/Content/Select2/select2-bootstrap.css"));

            bundles.Add(new StyleBundle("~/css/jstree").Include(
                      "~/Scripts/jqueryPlugins/jstree/dist/themes/default/style.min.css"));

            bundles.Add(new ScriptBundle("~/js/underscore").Include(
                      "~/Scripts/underscore-min.js"));

            bundles.Add(new ScriptBundle("~/js/cascadingDropDown").Include(
                        "~/Scripts/CascadingDropDown/jquery.cascadingDropDown.js"));

            bundles.Add(new StyleBundle("~/css/datetimepicker").Include(
                      "~/Content/DateTimePicker/bootstrap-datetimepicker.css"));

            bundles.Add(new ScriptBundle("~/js/datetimepicker").Include(
                      "~/Scripts/DateTimePicker/moment.min.js",
                      "~/Scripts/DateTimePicker/bootstrap-datetimepicker.js",
                      "~/Scripts/DateTimePicker/es.js"));

            bundles.Add(new StyleBundle("~/css/fileInput").Include(
                      "~/Content/BootstrapFileInput/fileinput.css"));

            bundles.Add(new ScriptBundle("~/js/fileInput").Include(
                      "~/Scripts/BootstrapFileInput/fileinput.js",
                      "~/Scripts/BootstrapFileInput/fileinput_locale_es.js"));

            bundles.Add(new ScriptBundle("~/js/unobstrusiveAjax").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}