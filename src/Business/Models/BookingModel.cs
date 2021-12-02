using System;

namespace Business.Models
{
    public class BookingModel
    {
        public decimal Price { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid? RentalPointId { get; set; }
        public RentalPointModel RentalPoint { get; set; }
        public Guid CarId { get; set; }
        public CarModel Car { get; set; }
        public DateTimeOffset KeyReceivingTime { get; set; }
        public DateTimeOffset KeyHandOverTime { get; set; }
        public DateTimeOffset BookingTime { get; set; }
    }
}