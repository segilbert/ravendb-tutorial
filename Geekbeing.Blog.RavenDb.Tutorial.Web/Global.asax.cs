using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace Geekbeing.Blog.RavenDb.Tutorial.Web
{
    public class MvcApplication : HttpApplication
    {
        private const string DatabaseName = "People";
        private static IDocumentStore _store;
        public static IDocumentStore DocumentStore
        {
            get { return _store; }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{pageNumber}",
                new { controller = "Home", action = "Index", pageNumber = UrlParameter.Optional } 
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterDocumentStore();
        }

        private void RegisterDocumentStore()
        {
            _store = new DocumentStore { ConnectionStringName = DatabaseName };
            _store.Initialize();
            _store.DatabaseCommands.EnsureDatabaseExists(DatabaseName);
            Raven.Client.MvcIntegration.RavenProfiler.InitializeFor(_store);
        }
    }
}