using FluentValidation;
using ProductService.Application.Models.Request;
using SharedLibrary.Helpers;

namespace ProductService.Infrastructure.FluentValidation
{
    public class CategoryCreateRequestCommandValidator : CustomAbstractValidator<CategoryCreateRequest>
    {
        public CategoryCreateRequestCommandValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Name is empty.");
            RuleFor(category => category.Description).NotEmpty().WithMessage("Description is empty.");
        }
    }

    public class CategoryUpdateRequestCommandValidator : CustomAbstractValidator<CategoryUpdateRequest>
    {
        public CategoryUpdateRequestCommandValidator()
        {
            RuleFor(category => category.Id).NotEmpty().WithMessage("Id is empty.");
        }
    }
}
