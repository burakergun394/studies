namespace Reservation.Domain.Reservations;

public class Reservation
{
    public int Id { get; set; }
    public int BookingNumber { get; set; }
    public DateTime? BookingDate { get; set; }
    public DateTime? CheckinDate { get; set; }
    public DateTime? CheckoutDate { get; set; }
    public decimal Amount { get; set; }
}
