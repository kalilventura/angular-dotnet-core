using CompanyAPI.Domain.Models;
using FluentValidation;

namespace CompanyAPI.Domain.Validations {
    public class RegisterValidator : AbstractValidator<Register> {
        public RegisterValidator () {
            RuleFor (user => user.Email)
                .NotEmpty ()
                .WithMessage ("Email is required.")
                .EmailAddress ()
                .WithMessage ("Invalid email format.");

            RuleFor (user => user.Password)
                .NotEmpty ()
                .WithMessage ("Password is required.")
                .Length (6, 100)
                .WithMessage ("Password need between 6 and 100 characters.");

            RuleFor (user => user.Username)
                .NotEmpty ()
                .WithMessage ("Username is required.")
                .NotNull ()
                .WithMessage ("Username is required.")
                .Length (3, 100)
                .WithMessage ("Username need between 3 and 100 characters.");

            RuleFor (user => user.FullName)
                .NotEmpty ()
                .WithMessage ("Fullname is required.")
                .NotNull ()
                .WithMessage ("Fullname is required.")
                .Length (3, 100)
                .WithMessage ("FullName need between 6 and 100 characters.");
        }
    }
}