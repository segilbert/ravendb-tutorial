using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Generators;

namespace Geekbeing.Blog.RavenDb.Tutorial.Initializer
{
    public static class FakePeopleProvider
    {
        public static Person GetFakePerson()
        {
            return Builder<Person>
                .CreateNew()
                .With(person => person.Name = GetRandom.FirstName())
                .And(person => person.Surname = GetRandom.LastName())
                .And(person => person.Email = GetRandom.Email())
                .And(person => person.AccountCreationTime = GetRandom.DateTimeThrough(DateTime.Today))
                .And(person => person.Age = GetRandom.PositiveInt(99))
                .And(person => person.AccountsInfo = new Collection<AccountInfo>
                                                         {
                                                             new AccountInfo { AccountIdentifier = GetRandom.Email(), Deposit = GetRandom.PositiveInt(10000)},
                                                             new AccountInfo { AccountIdentifier = GetRandom.Email(), Deposit = GetRandom.PositiveInt(10000)},
                                                             new AccountInfo { AccountIdentifier = GetRandom.Email(), Deposit = GetRandom.Int(-20000, 20000)}
                                                         }).Build();
        }

        public static ICollection<Person> GetFakePeople(int bodyCount)
        {
            ICollection<Person> createdFakes = new Collection<Person>();
            for (int i = 0; i < bodyCount; i++)
            {
                createdFakes.Add(GetFakePerson());
            }
            return createdFakes;
        }
    }
}