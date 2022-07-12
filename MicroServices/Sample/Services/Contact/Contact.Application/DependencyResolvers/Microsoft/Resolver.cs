using Contact.Application.Contacts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Application.DependencyResolvers.Microsoft;

public static class Resolver
{
    public static void DependencyResolveForApplicationLayer(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IContactService, ContactService>();
    }
}
