using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;
using SharedLibrary.Models;

namespace ProductService.Application.Interfaces
{
    public interface IProductService
    {
        Task<BaseResponse<ProductCreateRequest>> CreateProduct(ProductCreateRequest productCreateRequest);
        Task<BaseResponse<ProductResponse>> UpdateProduct(ProductUpdateRequest productUpdateRequest);
        Task<BaseResponse<NoContent>> DeleteProduct(string productId);
        Task<BaseResponse<IList<ProductResponse>>> GetAllProducts();
        Task<BaseResponse<ProductResponse>> GetProductById(string productId);
        Task<BaseResponse<IList<ProductResponse>>> GetProductsByCategoryId(string categoryId);
        Task<BaseResponse<IList<ProductResponse>>> GetProductsBySellerId(string sellerId);
        Task<BaseResponse<ProductResponse>> UpdateProductCategory(ProductCategoryUpdateRequest productCategoryUpdateRequest);
        Task<BaseResponse<IList<UpdateProductCategoryResponse>>> UpdateProductCategories(List<string> categoryIdList);
    }
}
