using API.Models.Request.Car;
using FluentValidation;

namespace API.Validators.Car
{
    public class UpdateCarRequestValidator : CarRequestValidator<UpdateCarRequest>
    {
        public UpdateCarRequestValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.Id)} should not be empty or NULL!");
            RuleFor(p => p.ImageId).NotNull().NotEmpty().WithMessage(p => $"{nameof(p.ImageId)} should not be empty or NULL!");
        }
    }
}