namespace Booking.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SeatId { get; set; }
        public Seat Seat { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
    }
}