using System.Collections.Generic;
using Geekbeing.Blog.RavenDb.Tutorial.Lib;

namespace Geekbeing.Blog.RavenDb.Tutorial.Web.Models
{
    public class PeoplePagedList
    {
        public PeoplePagedList(IEnumerable<Person> toBeDisplayed, int total, int perPage, int pageNumber)
        {
            ToBeDisplayed = toBeDisplayed;
            Total = total;
            PerPage = perPage;
            PageNumber = pageNumber;
        }

        public IEnumerable<Person> ToBeDisplayed { get; set; }
        public int Total { get; set; }
        public int PerPage { get; set; }
        public int PageNumber { get; set; }
    }
}