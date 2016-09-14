using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model
{
    class NumacDbContext:DbContext
    {
        public NumacDbContext()
            :base("NumacDataStore")
        {
            
        }

        public DbSet<NumacSystem> NumacSystems { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<ModuleBoard> ModuleBoards { get; set; }
    }
}
