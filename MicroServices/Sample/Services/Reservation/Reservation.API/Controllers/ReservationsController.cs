using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Reservations.Services;

namespace Reservation.API.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(reservationService.GetById(id));
        }
    }
}
