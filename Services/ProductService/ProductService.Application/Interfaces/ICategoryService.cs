using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;
using SharedLibrary.Models;

namespace ProductService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<BaseResponse<CategoryCreateRequest>> CreateCategory(CategoryCreateRequest categoryCreateRequest);
        Task<BaseResponse<CategoryResponse>> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest);
        Task<BaseResponse<NoContent>> DeleteCategory(string categoryId);
        Task<BaseResponse<IList<CategoryResponse>>> GetAllCategories();
        Task<BaseResponse<CategoryResponse>> GetCategoryById(string categoryId);
        Task<BaseResponse<IList<CategoryResponse>>> GetCategoriesByParentCategoryId(string categoryId);
    }
}
