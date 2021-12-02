using System;

namespace API.Models.Response.Booking
{
    public class BookingResponse
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTimeOffset KeyReceivingTime { get; set; }
        public DateTimeOffset KeyHandOverTime { get; set; }
        public DateTimeOffset BookingTime { get; set; }
    }
}