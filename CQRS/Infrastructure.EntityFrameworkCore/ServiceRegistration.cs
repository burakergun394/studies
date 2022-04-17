using Domain.Products;
using Infrastructure.EntityFrameworkCore.Contexts;
using Infrastructure.EntityFrameworkCore.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFrameworkCore
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddEntityFrameworkCoreServices(this IServiceCollection services)
        {
            services.AddDbContext<CustomDbContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-LKMPMHS;Initial Catalog=Burak;Integrated Security=True");
            });

            services.AddTransient<IProductRepository, EfCoreProductRepository>();

            return services;
        }
    }
}
