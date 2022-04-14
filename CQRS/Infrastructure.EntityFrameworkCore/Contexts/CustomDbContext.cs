using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore.Contexts
{
    public class CustomDbContext : DbContext
    {

        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // refactor edilecek
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-LKMPMHS;Initial Catalog=Burak;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}
