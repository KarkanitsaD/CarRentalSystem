using System;

namespace API.Models.Request.Booking
{
    public class CreateBookingFeedbackRequest
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookingId { get; set; }
    }
}