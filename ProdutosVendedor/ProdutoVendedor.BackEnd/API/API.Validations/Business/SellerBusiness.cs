using API.Domain.Models;
using FluentValidation;

namespace API.Validations.Business
{
    public class SellerBusiness : AbstractValidator<Seller>
    {
        private readonly string nameRegex = @"^[A-Za-záàâãéèêíïóôõöúüçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$";

        // Regras de validação para o vendedor
        public SellerBusiness()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("The Name cannot be null.")
                .NotEmpty().WithMessage("The Name cannot be blank.")
                .MinimumLength(3).WithMessage("The Name must contain at least 3 characters.")
                .MaximumLength(40).WithMessage("The Name must contain a maximum of 40 characters.")
                .Matches(nameRegex).WithMessage("The Name is invalid, please digit again.");

            RuleFor(x => x.CommissionValue)
                .NotNull().WithMessage("The Commission Value cannot be null.")
                .NotEmpty().WithMessage("The Commission Value cannot be blank.");
            //.LessThanOrEqualTo(0).WithMessage("The Commission Value cannot be less then or equal to 0.");

            RuleFor(x => x.Telephone)
                .NotNull().WithMessage("The Telephone cannot be null.")
                .NotEmpty().WithMessage("The Telephone cannot be blank.")
                .Length(9, 10).WithMessage("The Telephone number is invalid, please enter a valid number.");
        }
    }
}
