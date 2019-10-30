using CompanyAPI.Domain.ViewModel;
using FluentValidation;

namespace CompanyAPI.Domain.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Length(6, 100)
                .WithMessage("Password need between 6 and 100 characters.");

            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage("Username is required.");
        }
    }
}
