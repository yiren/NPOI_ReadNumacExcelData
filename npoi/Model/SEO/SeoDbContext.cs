using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model.SEO
{
    class SeoDbContext:DbContext
    {
        public SeoDbContext()
            :base("SeoDataStore")
        {
            
        }

        public DbSet<SeoDcr> SeoDcrs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityTypeSeoDcrConfiguration());
        }
    }

    internal class EntityTypeSeoDcrConfiguration:EntityTypeConfiguration<SeoDcr>
    {
        public EntityTypeSeoDcrConfiguration()
        {
            HasKey(d => d.DcrId);

        }
    }
}
