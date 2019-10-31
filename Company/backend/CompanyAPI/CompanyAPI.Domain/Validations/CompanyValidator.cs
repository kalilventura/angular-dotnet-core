using CompanyAPI.Domain.Models;
using FluentValidation;

namespace CompanyAPI.Domain.Validations
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required")
                .Length(6, 100)
                .WithMessage("Invalid Company Name");

            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Document is required")
                .Length(6, 100)
                .WithMessage("Invalid Document");
        }
    }
}
