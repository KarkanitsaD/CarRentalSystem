using System;

namespace API.Models.Request.Car
{
    public class AddCarRequestModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal FuelConsumptionPerHundredKilometers { get; set; }
        public string TransmissionType { get; set; }
        public int NumberOfSeats { get; set; }
        public string Color { get; set; }
        public Guid RentalPointId { get; set; }
        public string PictureBase64Content { get; set; }
        public string PictureShortName { get; set; }
        public string PictureExtension { get; set; }
    }
}