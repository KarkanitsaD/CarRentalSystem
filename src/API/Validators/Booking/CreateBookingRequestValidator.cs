using API.Models.Request.Booking;
using FluentValidation;

namespace API.Validators.Booking
{
    public class CreateBookingRequestValidator : AbstractValidator<CreateBookingRequest>
    {
        public CreateBookingRequestValidator()
        {
            RuleFor(p => p.CarId).NotNull().WithMessage("CarId should not be NULL!");
            RuleFor(p => p.RentalPointId).NotNull().WithMessage("RentalPointId should not be NULL!");
            RuleFor(p => p.KeyReceivingTime).NotNull().WithMessage("KeyReceivingTime should not be NULL!");
            RuleFor(p => p.KeyHandOverTime).NotNull().WithMessage("KeyHandOverTime should not be NULL!");
        }
    }
}