using System;

namespace Business.Models
{
    public class BookingFeedbackModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid CarId { get; set; }
        public CarModel Car { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid BookingId { get; set; }
        public BookingModel Booking { get; set; }
    }
}