using System.Web.Mvc;
using Raven.Client;

namespace Geekbeing.Blog.RavenDb.Tutorial.Web.Controllers
{
    public class BaseController : Controller
    {
        public IDocumentStore DocumentStore 
        {
            get
            {
                return MvcApplication.DocumentStore;
            }
        }
    }
}
