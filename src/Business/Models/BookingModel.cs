using System;

namespace Business.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? RentalPointId { get; set; }
        public Guid CarId { get; set; }
        public DateTime KeyReceivingTime { get; set; }
        public DateTime KeyHandOverTime { get; set; }
        public DateTime BookingTime { get; set; }
    }
}