using Microsoft.AspNetCore.Http.HttpResults;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
using SharedLibrary.Models;

namespace ProductService.Application.Interfaces
{
    public interface IProductService
    {
        Task<Response<ProductCreateRequest>> CreateProduct(ProductCreateRequest productCreateRequest);
        Task<Response<ProductResponse>> UpdateProduct(ProductUpdateRequest productUpdateRequest);
        Task<Response<NoContent>> DeleteProduct(string productId);
        Task<Response<IList<ProductResponse>>> GetAllProducts();
        Task<Response<ProductResponse>> GetProductById(string productId);
        Task<Response<IList<ProductResponse>>> GetProductsByCategoryId(string categoryId);
        Task<Response<IList<ProductResponse>>> GetProductsBySellerId(string sellerId);
        Task<Response<ProductResponse>> UpdateProductCategory(ProductCategoryUpdateRequest productCategoryUpdateRequest);
        Task<Response<List<UpdateProductCategoryResponse>>> UpdateProductCategories(List<string> categoryIdList);
    }
}
