using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class CarEntity : Entity
    {
        public string CarBrand { get; set; }
        public decimal FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public string VehicleNumber { get; set; }
        public Guid? RentalPointId { get; set; }
        public RentalPointEntity RentalPoint { get; set; }
        public bool IsBooked { get; set; }
        public DateTime LastViewTime { get; set; }
        public decimal PricePerDay { get; set; }
        public CarPictureEntity Picture { get; set; }

        public ICollection<BookingEntity> Bookings { get; set; }
    }
}