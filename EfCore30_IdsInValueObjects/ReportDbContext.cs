using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore30_IdsInValueObjects
{
    public class ReportDbContext : DbContext
    {
        public DbSet<ReportDiagram> ReportDiagrams { get; set; }
        public DbSet<Reports> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data source=SpongeBob.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDiagram>().Property(b => b.Id).HasConversion(idObject => idObject.ToString(), idString => new ReportDiagramId(idString));

            modelBuilder.Entity<Reports>().Property(b => b.ReportDiagramId).HasConversion(idObject => idObject.ToString(), idString => new ReportDiagramId(idString));

            base.OnModelCreating(modelBuilder);
        }
    }
}
