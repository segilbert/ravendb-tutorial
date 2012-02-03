using System.Linq;
using System.Web.Mvc;
using Geekbeing.Blog.RavenDb.Tutorial.Lib;
using Geekbeing.Blog.RavenDb.Tutorial.Web.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using Raven.Client.Linq;

namespace Geekbeing.Blog.RavenDb.Tutorial.Web.Controllers
{
    public class HomeController : Controller
    {
         private const string DatabaseName = "People";
         private static IDocumentStore _store;

         public HomeController()
         {
             if (_store == null)
             {
                 _store = new DocumentStore { ConnectionStringName = DatabaseName };
                 _store.Initialize();
                 _store.DatabaseCommands.EnsureDatabaseExists(DatabaseName);    
             }
         }

        public ActionResult Index(int pageNumber = 1)
        {
            RavenQueryStatistics stats;
            IQueryable<Person> queriedPeople;
            using (var session = _store.OpenSession())
            {
                var enforceTotalResults = session.Query<Person>().Statistics(out stats).Take(0).ToList();
                queriedPeople = session.Query<Person>();
            }
            PeoplePagedList list = new PeoplePagedList(queriedPeople) {PageNumber = pageNumber, PerPage = 10, Total = stats.TotalResults};
            return View(list);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
