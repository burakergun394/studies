using Reservation.Application.Reservations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Reservation.Application.DependencyResolvers.Microsoft;

public static class Resolver
{
    public static void DependencyResolveForApplicationLayer(this IServiceCollection serviceProvider)
    {
        serviceProvider.AddScoped<IReservationService, ReservationService>();
    }
}
