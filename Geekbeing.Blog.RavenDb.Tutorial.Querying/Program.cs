using System;
using Geekbeing.Blog.RavenDb.Tutorial.Initializer;
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

            using (IDocumentSession session = store.OpenSession())
            {
                RavenQueryStatistics queryStatistics;
                var firstFive = session.Query<Person>().Statistics(out queryStatistics).Take(5).ToList();
                Console.WriteLine(queryStatistics.TotalResults);
            }
        }
    }
}
