using Sample.Application.Common.Interfaces.Initializer;
using Sample.Domain.Products;
using Sample.Persistence.Data.EntityFrameworkCore.Context;

namespace Sample.Persistence.Data.EntityFrameworkCore.Common;

public class SeedInitializer : ISeedInitializer
{
    private readonly ApplicationDbContext context;

    public SeedInitializer(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task SeedAsync()
    {
        await SeedProductsAsync();
    }

    private async Task SeedProductsAsync()
    {
        if (!context.Products.Any())
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product-1", Quantity = 10, Price = 5 },
            new Product { Id = 2, Name = "Product-2", Quantity = 10, Price = 10 },
            new Product { Id = 3, Name = "Product-3", Quantity = 10, Price = 20 }
        };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
