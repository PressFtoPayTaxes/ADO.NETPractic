using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIntroductionPractic
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public bool IsDebtor { get; set; }
    }
}
