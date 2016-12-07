using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace generator
{
    class ApplicationContext: DbContext
    {
        public ApplicationContext(): base("DefaultConnection")
        {
        }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet Tournir { get; set; }

    }
}
