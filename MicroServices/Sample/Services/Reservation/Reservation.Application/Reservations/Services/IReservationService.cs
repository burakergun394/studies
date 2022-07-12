using Reservation.Application.Reservations.Dtos;

namespace Reservation.Application.Reservations.Services;

public interface IReservationService
{
    ReservationDto GetById(int id);
}
