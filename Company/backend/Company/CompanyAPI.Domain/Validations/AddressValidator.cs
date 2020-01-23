using CompanyAPI.Domain.Models;
using FluentValidation;

namespace CompanyAPI.Domain.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid City");

            RuleFor(x => x.Country)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Country");

            RuleFor(x => x.District)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid District");

            //RuleFor(x => x.Employee)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Invalid Employee");

            RuleFor(x => x.EmployeeId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Employee");

            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Number");

            RuleFor(x => x.State)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid State");

            RuleFor(x => x.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Street");

            RuleFor(x => x.Type)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Type");

            RuleFor(x => x.ZipCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid Zip Code");
        }
    }
}
