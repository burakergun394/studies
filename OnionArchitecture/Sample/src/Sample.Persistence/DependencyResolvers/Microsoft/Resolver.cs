using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Common.Interfaces.Initializer;
using Sample.Application.Products.Interfaces.Repositories;
using Sample.Persistence.Data.EntityFrameworkCore.Common;
using Sample.Persistence.Data.EntityFrameworkCore.Context;
using Sample.Persistence.Data.EntityFrameworkCore.Products;

namespace Sample.Persistence.DependencyResolvers.Microsoft;

public static class Resolver
{
    public static void DependencyResolveForPersistenceLayer(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("my-memory"));

        serviceProvider.AddScoped<ISeedInitializer, SeedInitializer>();

        serviceProvider.AddScoped<IProductRepository, ProductRepository>();
    }
}
