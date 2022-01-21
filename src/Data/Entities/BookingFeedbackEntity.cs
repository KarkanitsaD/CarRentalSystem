using System;

namespace Data.Entities
{
    public class BookingFeedbackEntity : Entity
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid BookingId { get; set; }
        public BookingEntity Booking { get; set; }
    }
}