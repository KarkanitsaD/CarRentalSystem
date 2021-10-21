using System;

namespace Business.Models
{
    public class CarModel
    {
        public Guid Id { get; set; }
        public string CarBrand { get; set; }
        public decimal FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public string VehicleNumber { get; set; }
        public Guid? RentalPointId { get; set; }
        public DateTime LastViewTime { get; set; }
        public decimal PricePerDay { get; set; }
    }
}