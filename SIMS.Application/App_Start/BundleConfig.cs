using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace SIMS.Application.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(bundle: new StyleBundle(virtualPath: "~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include(virtualPath: "~/Content/css/bootstrap-select.css")
                .Include(virtualPath: "~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include(virtualPath: "~/Content/css/skins/skin-blue.css"));

            bundles.Add(bundle: new ScriptBundle(virtualPath: "~/Bundles/js")
                .Include(virtualPath: "~/Content/js/plugins/jquery/jquery-3.3.1.js")
                .Include(virtualPath: "~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include(virtualPath: "~/Content/js/plugins/fastclick/fastclick.js")
                .Include(virtualPath: "~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include(virtualPath: "~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include(virtualPath: "~/Content/js/plugins/moment/moment.js")
                .Include(virtualPath: "~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include(virtualPath: "~/Content/js/plugins/icheck/icheck.js")
                .Include(virtualPath: "~/Content/js/plugins/validator/validator.js")
                .Include(virtualPath: "~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include(virtualPath: "~/Content/js/adminlte.js")
                .Include(virtualPath: "~/Content/js/init.js"));

            // 3rd party Js || Css
            bundles.Add(bundle: new StyleBundle(virtualPath: "~/Bundles/thirdPartyCss")
                .Include(virtualPath: "~/Content/DataTables/css/jquery.dataTables.min.css")
                .Include(virtualPath: "~/Content/DataTables/css/rowReorder.dataTables.css")
                .Include(virtualPath: "~/Content/DataTables/css/responsive.dataTables.css")
                .Include(virtualPath: "~/Content/jquery.fancybox.css")
                .Include(virtualPath: "~/Content/css/jquery-ui.css")
                .Include(virtualPath: "~/Content/css/jquery-jvectormap-2.0.3.css")
                .Include(virtualPath: "~/Content/toastr.css"));

            bundles.Add(bundle: new ScriptBundle(virtualPath: "~/Bundles/thirdPartyjs")
                .Include(virtualPath: "~/Scripts/DataTables/jquery.dataTables.min.js")
                .Include(virtualPath: "~/Scripts/DataTables/dataTables.rowReorder.js")
                .Include(virtualPath: "~/Scripts/DataTables/dataTables.responsive.js")
                .Include(virtualPath: "~/Scripts/bootbox.js")
                .Include(virtualPath: "~/Scripts/toastr.js")
                .Include(virtualPath: "~/Content/js/plugins/jquery/jquery-ui.js")
                .Include(virtualPath: "~/Scripts/Site.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
