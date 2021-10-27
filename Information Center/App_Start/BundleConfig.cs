using System.Web;
using System.Web.Optimization;

namespace Information_Center
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/normalize.css",
                       "~/Content/plugins/css/slick.css"
                       ));

            //for student_layout
            bundles.Add(new StyleBundle("~/Content/student-css").Include(
                      "~/Content/student-css/fonts/css/font-awesome.min.css",
                       "~/Content/student-css/css/index.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/plugins").Include(
                "~/Content/plugins/aos/aos.css",
                "~/Content/plugins/slick/slick.css"
                      ));
            bundles.Add(new StyleBundle("~/Scripts/plugins").Include(
                "~/Scripts/plugins/slick/slick.min.js",
                "~/Scripts/plugins/aos/aos.js",
                "~/Scripts/plugins/slick/slick-script.js"

                      ));

            bundles.Add(new StyleBundle("~/Content/student-css/login").Include(
                "~/Content/bootstrap.css",
                "~/Content/student-css/login/login.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/adminView").Include(
                      "~/Content/adminView/css/admin.css",
                      "~/Content/adminView/css/courseForm.css",
                      "~/Content/adminView/css/courses.css"

                      ));
            bundles.Add(new StyleBundle("~/Scripts/adminView").Include(
                      "~/Scripts/adminView/admin.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/course").Include(
                      "~/Content/course/course-details.css"

                      ));
            
        }
    }
}
