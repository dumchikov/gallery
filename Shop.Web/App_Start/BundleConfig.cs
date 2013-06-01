using System.Web.Optimization;

namespace Shop.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts").Include("~/Scripts/*.js"));
            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include("~/Scripts/bootstrap/*.js"));
            bundles.Add(new StyleBundle("~/css").Include("~/Content/css/*.css"));
        }
    }
}