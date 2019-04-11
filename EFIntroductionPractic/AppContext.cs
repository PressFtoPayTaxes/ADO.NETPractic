using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFIntroductionPractic
{
    public class AppContext : DbContext
    {
        public AppContext() : base("appContext")
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorAndBook> AuthorsAndBooks { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
    }
}
