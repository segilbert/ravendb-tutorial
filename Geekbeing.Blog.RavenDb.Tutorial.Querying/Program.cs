using Geekbeing.Blog.RavenDb.Tutorial.Lib;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using Raven.Client.Linq;
using System.Linq;

namespace Geekbeing.Blog.RavenDb.Tutorial.Querying
{
    class Program
    {
        private const string DatabaseName = "People";

        static void Main()
        {
            IDocumentStore store = new DocumentStore { ConnectionStringName = DatabaseName };
            store.Initialize();
            store.DatabaseCommands.EnsureDatabaseExists(DatabaseName);
            
            BasicQuerying(store);
            StatisticsQuerying(store);
        }

        private static void StatisticsQuerying(IDocumentStore store)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                RavenQueryStatistics queryStatistics;
                var people = session.Query<Person>().Statistics(out queryStatistics).Take(0).ToList();
                int peopleCount = queryStatistics.TotalResults;
            }
        }

        private static void BasicQuerying(IDocumentStore store)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var people = session.Query<Person>();
                var takeTenSkipFifty = people.Skip(50).Take(10);
                var result = takeTenSkipFifty.ToList();
                  
                var allPeople = session.Query<Person>().ToList();
            }
        }
    }
}
