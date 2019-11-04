using CompanyAPI.Domain.ViewModel;
using FluentValidation;

namespace CompanyAPI.Domain.Validations
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid Username");

            RuleFor(u => u.Password)
                 .NotEmpty()
                 .NotNull()
                 .WithMessage("Password Invalid");
        }
    }
}
