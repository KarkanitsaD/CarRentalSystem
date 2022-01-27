using API.Models.Request.RentalPoint;
using FluentValidation;

namespace API.Validators.RentalPoint
{
    public class UpdateRentalPointRequestValidator : AbstractValidator<UpdateRentalPointRequest>
    {
        public UpdateRentalPointRequestValidator()
        {
            RuleFor(p => p.Title).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Title)} should not be null or empty!");
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Id)} should not be empty or NULL!");
        }
    }
}