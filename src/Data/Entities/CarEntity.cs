using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class CarEntity : Entity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public Guid RentalPointId { get; set; }
        public RentalPointEntity RentalPoint { get; set; }
        public DateTime LastViewTime { get; set; }
        public CarPictureEntity Picture { get; set; }
        public CarLockEntity CarLockEntity { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }
        public ICollection<BookingFeedbackEntity> BookingFeedbacks { get; set; }
    }
}