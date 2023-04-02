using FluentValidation;
using ProductService.Application.Models.Requests;
using SharedLibrary.Helpers;

namespace ProductService.Infrastructure.FluentValidation
{
    public class ProductCreateRequestValidator : CustomAbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name is empty.");
            RuleFor(product => product.Description).NotEmpty().WithMessage("Description is empty.");
            RuleFor(product => product.Price).NotNull().WithMessage("Price is empty.");
            RuleFor(product => product.SellerId).NotEmpty().WithMessage("SellerId is empty.");
        }
    }

    public class ProductUpdateRequestValidator : CustomAbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
        {
            RuleFor(product => product.Id).NotEmpty().WithMessage("Id is empty.");
        }
    }
}
