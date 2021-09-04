using FluentValidation;
using WebApi.DTO;

namespace WebApi.Validation
{
    public class ProductValidator : AbstractValidator<dtoProduct>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Title).Length(3, 50).WithMessage("Incorect Title Length, only 3-50 symbols");
            RuleFor(x => x.Price).InclusiveBetween(1, 999).WithMessage("Price must be between 1 and 999");
        }
    }
}