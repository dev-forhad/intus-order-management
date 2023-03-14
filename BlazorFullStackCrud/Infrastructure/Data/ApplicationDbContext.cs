using BlazorFullStackCrud.Shared;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{

        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Window>()
            .Property(w => w.Id)
            .ValueGeneratedOnAdd();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }

    }

}
