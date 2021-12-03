using System;

namespace API.Models.Response.Booking
{
    public class BookingResponse
    {
        public decimal Price { get; set; }
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime KeyReceivingTime { get; set; }
        public DateTime KeyHandOverTime { get; set; }
        public DateTime BookingTime { get; set; }
    }
}