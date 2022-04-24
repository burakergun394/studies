using Core.CrossCuttinnConcerns.Caching;
using Core.CrossCuttinnConcerns.Caching.Microsoft;
using Infrastructure.EntityFrameworkCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<ICache, MicrosoftMemoryCache>();
            services.AddEntityFrameworkCoreServices();


            return services;
        }
    }
}
