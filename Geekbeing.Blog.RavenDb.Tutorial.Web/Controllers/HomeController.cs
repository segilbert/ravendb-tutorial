using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Geekbeing.Blog.RavenDb.Tutorial.Lib;
using Geekbeing.Blog.RavenDb.Tutorial.Web.Models;
using Raven.Client.Linq;

namespace Geekbeing.Blog.RavenDb.Tutorial.Web.Controllers
{
    public class HomeController : BaseController
    {
        private const int ResultsPerPage = 10;

        public ActionResult Index(int pageNumber = 1)
        {
            IEnumerable<Person> people;
            RavenQueryStatistics stats;
            IQueryable<Person> queriedPeople;
            using (var session = DocumentStore.OpenSession())
            {
                queriedPeople = session.Query<Person>().Statistics(out stats);
                people = queriedPeople.Skip((pageNumber - 1) * ResultsPerPage).Take(ResultsPerPage).ToList();
            }
            PeoplePagedList list = new PeoplePagedList(people, stats.TotalResults, ResultsPerPage, pageNumber);
            return View(list);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
