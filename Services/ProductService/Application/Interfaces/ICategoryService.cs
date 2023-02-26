using Microsoft.AspNetCore.Http.HttpResults;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
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
