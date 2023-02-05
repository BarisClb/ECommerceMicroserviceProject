using FluentValidation;
using ProductService.Application.Models.Request;
using SharedLibrary.Helpers;

namespace ProductService.Infrastructure.FluentValidation
{
    public class ProductCreateRequestCommandValidator : CustomAbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestCommandValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name is empty.");
            RuleFor(product => product.Description).NotEmpty().WithMessage("Description is empty.");
            RuleFor(product => product.Price).NotNull().WithMessage("Price is empty.");
            RuleFor(product => product.SellerId).NotEmpty().WithMessage("SellerId is empty.");
        }
    }

    public class ProductUpdateRequestCommandValidator : CustomAbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestCommandValidator()
        {
            RuleFor(product => product.Id).NotEmpty().WithMessage("Id is empty.");
        }
    }
}
