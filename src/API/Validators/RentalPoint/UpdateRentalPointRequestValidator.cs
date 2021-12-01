using API.Models.Request.RentalPoint;
using FluentValidation;

namespace API.Validators.RentalPoint
{
    public class UpdateRentalPointRequestValidator : RentalPointRequestValidator<UpdateRentalPointRequest>
    {
        public UpdateRentalPointRequestValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Id)} should not be empty or NULL!");
        }
    }
}