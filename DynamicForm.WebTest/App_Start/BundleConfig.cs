using System.Web;
using System.Web.Optimization;

namespace DynamicForm.WebTest
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/basic_Styles").Include(
             "~/Content/bootstrap.min.css",
             "~/assets/css/font-awesome.min.css",
             "~/assets/css/jquery-ui.custom.min.css",
             "~/assets/css/ace.min.css",
             "~/assets/css/ace-part2.min.css",
             "~/assets/css/ace-skins.min.css",
             "~/assets/css/ace-ie.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/basic_Scripts").Include
                (
                 "~/assets/js/ace-extra.min.js",
                 "~/assets/js/jquery-1.10.2.min.js",
                 "~/Scripts/bootstrap.min.js",
                 "~/assets/js/jquery-ui.custom.min.js",
                 "~/assets/js/jquery.ui.touch-punch.min.js",
                 "~/assets/js/jquery.knob.min.js",
                 "~/assets/js/jquery.autosize.min.js",
                 "~/assets/js/bootstrap-tag.min.js",
                 "~/assets/js/ace-elements.min.js",
                 "~/assets/js/ace.min.js"
                ));
        }
    }
}