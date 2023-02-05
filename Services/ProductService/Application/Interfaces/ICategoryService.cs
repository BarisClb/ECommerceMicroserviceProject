using Microsoft.AspNetCore.Http.HttpResults;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
using SharedLibrary.Models;

namespace ProductService.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<CategoryCreateRequest>> CreateCategory(CategoryCreateRequest categoryCreateRequest);
        Task<Response<CategoryResponse>> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest);
        Task<Response<NoContent>> DeleteCategory(string categoryId);
        Task<Response<IList<CategoryResponse>>> GetAllCategories();
        Task<Response<CategoryResponse>> GetCategoryById(string categoryId);
        Task<Response<IList<CategoryResponse>>> GetCategoriesByParentCategoryId(string categoryId);
    }
}
