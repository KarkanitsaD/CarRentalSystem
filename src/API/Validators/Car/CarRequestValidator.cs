using API.Models.Request.Car;
using FluentValidation;

namespace API.Validators.Car
{
    public class CarRequestValidator<TRequest> : AbstractValidator<TRequest> where TRequest : CarRequest
    {
        public CarRequestValidator()
        {
            RuleFor(p => p.Brand).NotNull().NotEmpty().WithMessage(p => $"{p.Brand}should not be null or empty!");
            RuleFor(p => p.Model).NotNull().NotEmpty().WithMessage(p => $"{p.Model} should not be null or empty!");
            RuleFor(p => p.PricePerDay).NotNull().WithMessage(p => $"{p.PricePerDay} should not be null or empty!");
            RuleFor(p => p.PricePerDay).Must(IsPositiveValue).WithMessage(p => $"{p.PricePerDay} should be positive!");
            RuleFor(p => p.FuelConsumptionPerHundredKilometers).NotNull().WithMessage(p => $"{p.FuelConsumptionPerHundredKilometers} should not be null or empty!");
            RuleFor(p => p.FuelConsumptionPerHundredKilometers).Must(IsPositiveValue).WithMessage(p => $"{p.FuelConsumptionPerHundredKilometers} should be positive!");
            RuleFor(p => p.NumberOfSeats).NotNull().NotEmpty().WithMessage(p => $"{p.NumberOfSeats} should not be null or empty!");
            RuleFor(p => p.NumberOfSeats).Must(IsPositiveValue).WithMessage(p => $"{p.NumberOfSeats} should be positive!");
            RuleFor(p => p.RentalPointId).NotNull().NotEmpty().WithMessage(p => $"{p.RentalPointId} should not be null or empty!");
            RuleFor(p => p.PictureBase64Content).NotNull().NotEmpty().WithMessage(p => $"{p.PictureBase64Content} should not be null or empty!");
            RuleFor(p => p.PictureShortName).NotNull().NotEmpty().WithMessage(p => $"{p.PictureShortName} should not be null or empty!");
            RuleFor(p => p.PictureExtension).NotNull().NotEmpty().WithMessage(p => $"{p.PictureExtension} should not be null or empty!");
        }

        private bool IsPositiveValue(decimal val)
        {
            return val > 0;
        }

        private bool IsPositiveValue(int val)
        {
            return val > 0;
        }
    }
}