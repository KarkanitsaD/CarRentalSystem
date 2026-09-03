using System.Text.RegularExpressions;
using API.Models.Request.User;
using FluentValidation;

namespace API.Validators.User
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(p => p.Password).Must(IsValidPassword).WithMessage(p =>
                $"{nameof(p.Password)} must be more than 5 characters long, contain letters of the English alphabet and contain at least one number.");
            RuleFor(p => p.Email).EmailAddress().WithMessage(p => $"Invalid {p.Email}");
            RuleFor(p => p.Name).Must(IsValidName).WithMessage(p => $"{nameof(p.Name)} should start with title letter and contains more the one symbol");
            RuleFor(p => p.Surname).Must(IsValidName).WithMessage(p => $"{nameof(p.Surname)} should start with title letter and contains more the one symbol");
        }

        private bool IsValidPassword(string password)
        {
            Regex rgx = new Regex("^((?=.*[0-9])(?=.*[a-zA-Z])[0-9a-zA-Z]{6,})$");
            return rgx.IsMatch(password);
        }

        private bool IsValidName(string name)
        {
            Regex rgx = new Regex("^[A-ZА-Я][a-zа-я]+$");
            return rgx.IsMatch(name);
        }
    }
}