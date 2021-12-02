using System;

namespace API.Models.Request.Booking
{
    public class CreateBookingRequest
    {
        public decimal Price { get; set; }
        public Guid CarId { get; set; }
        public Guid RentalPointId { get; set; }
        public DateTimeOffset KeyReceivingTime { get; set; }
        public DateTimeOffset KeyHandOverTime { get; set; }
    }
}