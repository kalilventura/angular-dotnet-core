using CompanyAPI.Domain.Models;
using FluentValidation;

namespace CompanyAPI.Domain.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Document)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Document");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid Email");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Name");
        }
    }
}
