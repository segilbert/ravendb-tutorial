using System;
using System.Globalization;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;

namespace Geekbeing.Blog.RavenDb.Tutorial.Initializer
{
    class Program
    {
        private const string DatabaseName = "People";
        private const int PeopleCount = 220;

        static void Main()
        {
            IDocumentStore store = new DocumentStore { ConnectionStringName = DatabaseName };
            store.Initialize();
            store.DatabaseCommands.EnsureDatabaseExists(DatabaseName);

            var people = FakePeopleProvider.GetFakePeople(PeopleCount);

            using (IDocumentSession session = store.OpenSession())
            {
                foreach (var person in people)
                {
                    session.Store(person);
                }
                session.SaveChanges();
            }
            Console.WriteLine(
                string.Format(CultureInfo.InvariantCulture, 
                "Database '{0}' has been initialized with {1} people. \nEach of them has 3 accounts, holding different amounts of money",
                DatabaseName, PeopleCount));
        }
    }
}