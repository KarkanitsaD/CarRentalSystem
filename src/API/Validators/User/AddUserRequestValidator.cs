using System.Text.RegularExpressions;
using API.Models.Request.User;
using FluentValidation;

namespace API.Validators.User
{
    public class AddUserRequestValidator : UserRequestValidator<CreateUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(p => p.Password).Must(IsValidPassword).WithMessage(p =>
                $"{nameof(p.Password)} must be more than 5 characters long, contain letters of the English alphabet and contain at least one number.");
        }

        private bool IsValidPassword(string password)
        {
            Regex rgx = new Regex("^((?=.*[0-9])(?=.*[a-zA-Z])[0-9a-zA-Z]{6,})$");
            return rgx.IsMatch(password);
        }
    }
}