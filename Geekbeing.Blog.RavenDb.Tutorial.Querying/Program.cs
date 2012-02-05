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
        private static readonly IDocumentStore Store = new DocumentStore { ConnectionStringName = DatabaseName };

        static void Main()
        {
            Store.Initialize();
            Store.DatabaseCommands.EnsureDatabaseExists(DatabaseName);
            
            BasicQuerying();
            StatisticsQuerying();
            QueryAllOfTheGirlsWithNameLaura();
            QueryWithLinqSyntax();
        }

        private static void QueryWithLinqSyntax()
        {
            using (IDocumentSession session = Store.OpenSession())
            {
                var lauras = from person in session.Query<Person>()
                             where person.Name == "Laura"
                             select person;
                //at this point no call to Raven has been made!

                var fetchedLauras = lauras.ToList();
                //and now all the Lauras are here
            }
        }

        private static void QueryAllOfTheGirlsWithNameLaura()
        {
            using (IDocumentSession session = Store.OpenSession())
            {
                //data for 'people' database is generated randomly. It might not yield any results on your machine, try different name then, to see it works
                var lauras = session.Query<Person>().Where(person => person.Name == "Laura").ToList();
            }
        }

        private static void StatisticsQuerying()
        {
            using (IDocumentSession session = Store.OpenSession())
            {
                RavenQueryStatistics queryStatistics;
                var people = session.Query<Person>().Statistics(out queryStatistics).Take(0).ToList();
                int peopleCount = queryStatistics.TotalResults;
            }
        }

        private static void BasicQuerying()
        {
            using (IDocumentSession session = Store.OpenSession())
            {
                var people = session.Query<Person>();
                var takeTenSkipFifty = people.Skip(50).Take(10);
                var result = takeTenSkipFifty.ToList();
                  
                var allPeople = session.Query<Person>().ToList();
            }
        }
    }
}
