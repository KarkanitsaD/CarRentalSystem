using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class CarModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public Guid RentalPointId { get; set; }
        public RentalPointModel RentalPoint { get; set; }
        public DateTime LastViewTime { get; set; }
        public decimal PricePerDay { get; set; }
        public CarPictureModel Picture { get; set; }

        public ICollection<BookingModel> Bookings { get; set; }
    }
}