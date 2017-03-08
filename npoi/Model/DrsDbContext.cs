using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LungmenSoftware.Models.DRS
{
    public class DrsDbContext:DbContext
    {
        public DrsDbContext()
            : base("DrsDataStore")
        {

        }

        public DbSet<DrsSystem> DrsSystems { get; set; }
        public DbSet<DrsPanel> DrsPanels { get; set; }

        public DbSet<FID> FIDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityTypeConfigurationDrsSystem());
            modelBuilder.Configurations.Add(new EntityTypeConfigurationDrsPanel());
            modelBuilder.Configurations.Add(new EntityTypeConfigurationFID());

        }

        private class EntityTypeConfigurationDrsSystem : EntityTypeConfiguration<DrsSystem>
        {
            public EntityTypeConfigurationDrsSystem()
            {
                HasKey(s => s.SystemId);
                Property(s => s.SystemName).HasMaxLength(20);
                HasMany(s => s.DrsPanel).WithRequired(p => p.DrsSystem).HasForeignKey(s => s.DrsPanelId);
            }
        }

        private class EntityTypeConfigurationDrsPanel : EntityTypeConfiguration<DrsPanel>
        {
            public EntityTypeConfigurationDrsPanel()
            {
                HasKey(p => p.DrsPanelId);
                Property(p => p.DrsPanelName).HasMaxLength(50);
                HasMany(p => p.FIDs).WithRequired(f => f.DrsPanel).HasForeignKey(p => p.FidId);
            }
        }

        private class EntityTypeConfigurationFID : EntityTypeConfiguration<FID>
        {
            public EntityTypeConfigurationFID()
            {
                HasKey(f => f.FidId);
                Property(f => f.FidDiagramNo).HasMaxLength(50);
                Property(f => f.ModuleType).HasMaxLength(50);
                Property(f => f.EPROMSpecNo).HasMaxLength(50);
                Property(f => f.Rev).HasMaxLength(20);
                Property(f => f.Checksum).HasMaxLength(50);
            }
        }
    }
}