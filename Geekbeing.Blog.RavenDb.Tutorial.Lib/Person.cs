using System;
using System.Collections.Generic;

namespace Geekbeing.Blog.RavenDb.Tutorial.Lib
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime AccountCreationTime { get; set; }

        public ICollection<AccountInfo> AccountsInfo { get; set; }
    }

    public class AccountInfo
    {
        public string AccountIdentifier { get; set; }
        public int Deposit { get; set; }
    }
}