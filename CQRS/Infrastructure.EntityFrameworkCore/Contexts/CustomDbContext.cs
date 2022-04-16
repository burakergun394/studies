using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore.Contexts
{
    public class CustomDbContext : DbContext
    {

        public CustomDbContext(DbContextOptions options) : base(options)
        {

        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
