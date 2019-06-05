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
        public DbSet<Report> Reports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data source=SpongeBob.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //conversion only works with single parameter
            //modelBuilder.Entity<ReportDiagram>().Property(b => b.Id).HasConversion(idObject => idObject.ToString(), idString => new ReportDiagramId());

            //conversion only works with single parameter
            //modelBuilder.Entity<Reports>().Property(b => b.ReportDiagramId).HasConversion(idObject => idObject.ToString(), idString => new ReportDiagramId());

            base.OnModelCreating(modelBuilder);
        }
    }
}
