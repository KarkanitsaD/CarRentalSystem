using System;

namespace API.Models.Response.Booking
{
    public class BookingFeedbackResponse
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookingId { get; set; }
    }
}