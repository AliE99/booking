using System;

namespace Booking.Models
{
    public class Show
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}