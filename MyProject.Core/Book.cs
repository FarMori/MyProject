using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core
{
    public class Book 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AuthorBook> AuthorBooks { get; set;} = new List<AuthorBook>();
    }
}
