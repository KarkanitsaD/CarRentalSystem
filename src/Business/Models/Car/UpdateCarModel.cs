using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Models.Car
{
    public class UpdateCarModel
    {
        [Required(ErrorMessage = "Id can't be null")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Brand can't be null")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model can't be null")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Price per day cant be null")]
        public float PricePerDay { get; set; } = (float)15.4;

        [Required(ErrorMessage = "FuelConsumptionPerHundredKilometers can't be null")]
        public float FuelConsumptionPerHundredKilometers { get; set; }

        [Required(ErrorMessage = "Number of seats can't be null")]
        public int NumberOfSeats { get; set; }

        public string TransmissionType { get; set; }

        public string Color { get; set; }

        [Required(ErrorMessage = "PictureExtension can't be null")]
        public string PictureExtension { get; set; }

        [Required(ErrorMessage = "Rental point id can't be null")]
        public Guid RentalPointId { get; set; }

        [Required(ErrorMessage = "Picture short name can't be null")]
        public string PictureShortName { get; set; }

        [Required(ErrorMessage = "Picture content can't be null")]
        public string PictureBase64Content { get; set; }
    }
}