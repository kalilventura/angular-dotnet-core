using API.Domain.Models;
using FluentValidation;

namespace API.Validations.Business
{
    public class ProductBusiness : AbstractValidator<Product>
    {
        private readonly string nameRegex = @"^[A-Za-záàâãéèêíïóôõöúüçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$";

        // TODO: Colocar as regras de negócio para o produto
        public ProductBusiness()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("The Name cannot be null.")
                .NotEmpty().WithMessage("The Name cannot be blank.")
                .MinimumLength(3).WithMessage("The Name must contain at least 3 characters.")
                .MaximumLength(40).WithMessage("The Name must contain a maximum of 40 characters.")
                .Matches(nameRegex).WithMessage("The Name is invalid, please digit again.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("The Price cannot be null.")
                .NotEmpty().WithMessage("The Price cannot be blank.");
                //.LessThanOrEqualTo(0).WithMessage("The Price cannot be less then or equal to 0.");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("The Description cannot be null.")
                .NotEmpty().WithMessage("The Description cannot be blank.")
                .MaximumLength(40).WithMessage("The Description must contain a maximum of 40 characters.");

            RuleFor(x => x.BarCode)
                .NotNull().WithMessage("The Bar Code cannot be null.")
                .NotEmpty().WithMessage("The Bar Code cannot be blank.");
        }
    }
}
