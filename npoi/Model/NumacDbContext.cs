using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model
{
    public class NumacDbContext:DbContext
    {
        public NumacDbContext()
            :base("NumacDataStore")
        {
            
        }

        public DbSet<NumacSystem> NumacSystems { get; set; }
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<ModuleBoard> ModuleBoards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityTypeConfigurationSystem());
            modelBuilder.Configurations.Add(new EntityTypeConfigurationChassis());
            modelBuilder.Configurations.Add(new EntityTypeConfigurationModuleBoard());

        }
    }

    public class EntityTypeConfigurationModuleBoard:EntityTypeConfiguration<ModuleBoard>
    {
        public EntityTypeConfigurationModuleBoard()
        {
            HasKey(b => b.ModuleBoardId);

        }
    }

    class EntityTypeConfigurationChassis:EntityTypeConfiguration<Chassis>
    {
        public EntityTypeConfigurationChassis()
        {
            HasKey(c => c.ChassisId);
            HasMany(c => c.ModuleBoards).WithRequired(b => b.Chassis).HasForeignKey(b => b.ChassisId);
        }
    }

    class EntityTypeConfigurationSystem:EntityTypeConfiguration<NumacSystem>
    {
        public EntityTypeConfigurationSystem()
        {
            HasKey(s => s.SystemId);
            HasMany(s => s.Chassis).WithRequired(s => s.NumacSystem).HasForeignKey(c => c.SystemId);
            
        }
        
    }
}
