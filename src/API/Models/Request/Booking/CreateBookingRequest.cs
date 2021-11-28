using System;

namespace API.Models.Request.Booking
{
    public class CreateBookingRequest
    {
        public Guid CarId { get; set; }
        public Guid RentalPointId { get; set; }
        public DateTime KeyReceivingTime { get; set; }
        public DateTime KeyHandOverTime { get; set; }
    }
}