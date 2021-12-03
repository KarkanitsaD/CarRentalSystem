using System.Text.RegularExpressions;
using API.Models.Request.User;
using FluentValidation;

namespace API.Validators.User
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage(p => $"{nameof(p.Id)} can't be empty or NULL!");
            RuleFor(p => p.Email).EmailAddress().WithMessage(p => $"Invalid {p.Email}");
            RuleFor(p => p.Name).Must(IsValidName).WithMessage(p => $"{nameof(p.Name)} should start with title letter and contains more the one symbol");
            RuleFor(p => p.Surname).Must(IsValidName).WithMessage(p => $"{nameof(p.Surname)} should start with title letter and contains more the one symbol");
        }

        private static bool IsValidName(string name)
        {
            Regex rgx = new Regex("^[A-ZА-Я][a-zа-я]+$");
            return rgx.IsMatch(name);
        }
    }
}