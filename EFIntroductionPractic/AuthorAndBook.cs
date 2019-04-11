using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIntroductionPractic
{
    public class AuthorAndBook : Entity
    {
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
