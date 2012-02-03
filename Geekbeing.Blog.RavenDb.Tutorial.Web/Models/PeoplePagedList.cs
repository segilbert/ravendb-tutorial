using System.Collections.Generic;
using System.Linq;
using Geekbeing.Blog.RavenDb.Tutorial.Lib;

namespace Geekbeing.Blog.RavenDb.Tutorial.Web.Models
{
    public class PeoplePagedList
    {
        private readonly IQueryable<Person> _people;

        public PeoplePagedList(IQueryable<Person> people)
        {
            _people = people;
        }

        public int Total { get; set; }
        public int PerPage { get; set; }
        public int PageNumber { get; set; }

        public IEnumerable<Person> GetCurrent(int pageNumber)
        {
            return _people.Skip((pageNumber - 1)*PerPage).Take(PerPage).ToList();
        }
    }
}