using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace easylife
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            StyleBundle UserHomeCss = new StyleBundle("~/UserHome");
            UserHomeCss.Include("~/Styles/Style_user.css");
            UserHomeCss.Include("~/Styles/bootstrap.min.css");
            UserHomeCss.Include("~/Styles/easyzoom.css");

            bundles.Add(UserHomeCss);

            StyleBundle UserDashBoardCss = new StyleBundle("~/UserDashboard");
            UserDashBoardCss.Include("~/Styles/Style_user.css");
            UserDashBoardCss.Include("~/Styles/AdminLTE.min.css");

            bundles.Add(UserDashBoardCss);

            StyleBundle AdminCss = new StyleBundle("~/Admin");
            AdminCss.Include("~/Styles/Style.css");
            AdminCss.Include("~/Styles/w3.css");
            AdminCss.Include("~/Styles/table.css");
            AdminCss.Include("~/Styles/AdminLTE.min.css");

            bundles.Add(AdminCss);

            BundleTable.EnableOptimizations = true;

        }
    }
}