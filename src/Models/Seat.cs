namespace Booking.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}