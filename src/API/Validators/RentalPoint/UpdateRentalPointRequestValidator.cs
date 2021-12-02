using API.Models.Request.RentalPoint;
using FluentValidation;

namespace API.Validators.RentalPoint
{
    public class UpdateRentalPointRequestValidator : AbstractValidator<UpdateRentalPointRequest>
    {
        public UpdateRentalPointRequestValidator()
        {
            RuleFor(p => p.Title).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Title)} should not be null or empty!");
            RuleFor(p => p.Address).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Address)} should not be null or empty!");
            RuleFor(p => p.LocationX).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.LocationX)} should not be null or empty!");
            RuleFor(p => p.LocationX).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.LocationY)} should not be null or empty!");
            RuleFor(p => p.LocationX).Must(IsValidLocationX).WithMessage(p => $"{nameof(p.LocationX)} should be >= -90 and <= 90!");
            RuleFor(p => p.LocationY).Must(IsValidLocationY).WithMessage(p => $"{nameof(p.LocationY)} should be >= -180 and <= 180!");
            RuleFor(p => p.Country).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Country)} should be not be empty or NULL!");
            RuleFor(p => p.City).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.City)} should be not be empty or NULL!");
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Id)} should not be empty or NULL!");
        }

        private static bool IsValidLocationX(float locationX)
        {
            return locationX >= -90 && locationX <= 90;
        }
        private static bool IsValidLocationY(float locationY)
        {
            return locationY >= -180 && locationY <= 180;
        }
    }
}