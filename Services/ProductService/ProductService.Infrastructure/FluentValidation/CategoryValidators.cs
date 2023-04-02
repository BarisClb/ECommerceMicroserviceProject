using FluentValidation;
using ProductService.Application.Models.Requests;
using SharedLibrary.Helpers;

namespace ProductService.Infrastructure.FluentValidation
{
    public class CategoryCreateRequestValidator : CustomAbstractValidator<CategoryCreateRequest>
    {
        public CategoryCreateRequestValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Name is empty.");
            RuleFor(category => category.Description).NotEmpty().WithMessage("Description is empty.");
        }
    }

    public class CategoryUpdateRequestValidator : CustomAbstractValidator<CategoryUpdateRequest>
    {
        public CategoryUpdateRequestValidator()
        {
            RuleFor(category => category.Id).NotEmpty().WithMessage("Id is empty.");
        }
    }
}
