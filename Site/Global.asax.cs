using System;
using System.Web.DynamicData;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;
using Microsoft.AspNet.DynamicData.ModelProviders;
using X.DynamicData.Core;

namespace Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterBundles(BundleTable.Bundles);
            RegisterScripts(ScriptManager.ScriptResourceMapping);
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            var contextConfiguration = new ContextConfiguration { ScaffoldAllTables = Global.Context.ScaffoldAllTables };

            if (Global.CanCreateDataContext())
            {
                //Global.MetaModel.RegisterContext(() => Global.CreateDataContext(Global.Context.DataContextAssemblyLocation), contextConfiguration);

                Global.MetaModel.RegisterContext(
                    new EFDataModelProvider(() => Global.CreateDataContext(Global.Context.DataContextAssemblyLocation)),
                    contextConfiguration);

                routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
                {
                    Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert" }),
                    Model = Global.MetaModel
                });
            }
        }

        private static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new Bundle("~/js").IncludeDirectory("~/Scripts", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/normalize.css",
                                                         "~/Content/site.css",
                                                         "~/Content/chosen.css",
                                                         "~/Content/signin.css",
                                                         "~/Content/bootstrap.css",
                                                         "~/Content/bootstrap-datepicker.css",
                                                         "~/Content/x.bootstrap.css",
                                                         "~/Content/custom.css"));

        }

        private static void RegisterScripts(ScriptResourceMapping scriptResourceMapping)
        {
            scriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-2.1.1.min.js",
                DebugPath = "~/Scripts/jquery-2.1.1.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.1.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.1.1.js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });
        }
    }
}