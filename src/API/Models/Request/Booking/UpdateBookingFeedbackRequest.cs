using System;

namespace API.Models.Request.Booking
{
    public class UpdateBookingFeedbackRequest
    {
        public Guid BookingFeedbackId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}