using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Products.Interfaces.Services;
using Sample.Infrastructure.Products.Services;

namespace Sample.Infrastructure.DependencyResolvers.Microsoft;

public static class Resolver
{
    public static void DependencyResolveForInfrastructureLayer(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IProductService, ProductService>();
    }
}
