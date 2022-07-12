using Reservation.Application.Reservations.Dtos;

namespace Reservation.Application.Reservations.Services;

public class ReservationService : IReservationService
{
    public ReservationDto GetById(int id)
    {
        return new ReservationDto
        {
            Id = id,
            BookingNumber = 0,
            BookingDate = DateTime.Now,
            CheckinDate = DateTime.Now.AddDays(2),
            CheckoutDate = DateTime.Now.AddDays(5),
            Amount = 1000,
        };
    }
}
