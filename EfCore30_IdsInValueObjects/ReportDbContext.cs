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
            //with conversion it works, but it is evaluated locally
            modelBuilder.Entity<ReportDiagram>().Property(b => b.Id).HasConversion(idObject => idObject.ToString(), idString => new ReportDiagramId(idString));

            //same as above, the next line does not work, because Post needs an id
            //modelBuilder.Entity<Post>().OwnsOne(p => p.Id);

            //the next line works, but the following code is evaluated locally: 
            //var postsOfBlog123 = DbContext.Posts.Where(p => p.BlogId == new BlogId("123")).ToList();
            //'Error generated for warning 'Microsoft.EntityFrameworkCore.Query.QueryClientEvaluationWarning: The LINQ expression 'where ([p.BlogId] == value(EfCore30_IdsInValueObjects.BlogId))' could not be translated and will be evaluated locally.'. 
            modelBuilder.Entity<Post>().Property(b => b.Id).HasConversion(idObject => idObject.Value, idString => new PostId(idString));

            modelBuilder.Entity<Post>().OwnsOne(p => p.BlogId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
