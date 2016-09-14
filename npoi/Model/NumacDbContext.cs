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
    }
}
