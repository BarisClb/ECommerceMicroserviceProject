using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
using ProductService.Domain.Entities;
using ProductService.Domain.Helpers;
using SharedLibrary.Models;

namespace ProductService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<ProductCreateRequest>> CreateProduct(ProductCreateRequest productCreateRequest)
        {
            var product = _mapper.Map<Product>(productCreateRequest);
            var category = await _categoryRepository.GetByIdAsync(productCreateRequest.CategoryId);

            product.ProductCategory = new ProductCategory() { CategoryId = category?.Id, CategoryName = category?.Name };
            product.CreatedOn = DateTime.UtcNow;
            await _productRepository.InsertAsync(product);
            return BaseResponse<ProductCreateRequest>.Success(productCreateRequest, 201);
        }

        public async Task<BaseResponse<ProductResponse>> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            var productUpdateBuilder = Builders<Product>.Update;
            var productUpdates = new List<UpdateDefinition<Product>>();

            if (!string.IsNullOrEmpty(productUpdateRequest.Name))
                productUpdates.Add(productUpdateBuilder.Set(c => c.Name, productUpdateRequest.Name));
            if (!string.IsNullOrEmpty(productUpdateRequest.Description))
                productUpdates.Add(productUpdateBuilder.Set(c => c.Description, productUpdateRequest.Description));
            if (productUpdateRequest.Price != null)
                productUpdates.Add(productUpdateBuilder.Set(c => c.Price, productUpdateRequest.Price));
            if (!string.IsNullOrEmpty(productUpdateRequest.Image))
                productUpdates.Add(productUpdateBuilder.Set(c => c.Image, productUpdateRequest.Image));
            if (!string.IsNullOrEmpty(productUpdateRequest.SellerId))
                productUpdates.Add(productUpdateBuilder.Set(c => c.SellerId, productUpdateRequest.SellerId));
            if (!string.IsNullOrEmpty(productUpdateRequest.CategoryId))
            {
                var category = await _categoryRepository.GetByIdAsync(productUpdateRequest.CategoryId);
                if (category != null)
                    productUpdates.Add(productUpdateBuilder.Set(c => c.ProductCategory, new ProductCategory() { CategoryId = category.Id, CategoryName = category.Name }));
            }

            if (productUpdates.Count == 0)
                return BaseResponse<ProductResponse>.Fail($"No values provided to Update Product. ProductId: '{productUpdateRequest.Id}'.", 400);

            productUpdates.Add(productUpdateBuilder.Set(c => c.ModifiedOn, DateTime.UtcNow));
            var updatedProduct = await _productRepository.UpdateAndGetByIdAsync(productUpdateRequest.Id, productUpdateBuilder.Combine(productUpdates));

            if (updatedProduct == null)
                return BaseResponse<ProductResponse>.Fail($"Failed to Update Product. ProductId: '{productUpdateRequest.Id}'.", 500);

            return BaseResponse<ProductResponse>.Success(_mapper.Map<ProductResponse>(updatedProduct), 200);
        }

        public async Task<BaseResponse<NoContent>> DeleteProduct(string productId)
        {
            var result = await _productRepository.DeleteByIdAsync(productId);

            if (!result)
                return BaseResponse<NoContent>.Fail($"Failed to Delete Product. ProductId: '{productId}'.", 400);

            return BaseResponse<NoContent>.Success(204);
        }

        public async Task<BaseResponse<IList<ProductResponse>>> GetAllProducts()
        {
            var products = await _productRepository.GetWhereAsync(c => true);
            return BaseResponse<IList<ProductResponse>>.Success(_mapper.Map<IList<ProductResponse>>(products), 200);
        }

        public async Task<BaseResponse<ProductResponse>> GetProductById(string productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return BaseResponse<ProductResponse>.Success(_mapper.Map<ProductResponse>(product), 200);
        }

        public async Task<BaseResponse<IList<ProductResponse>>> GetProductsByCategoryId(string categoryId)
        {
            var products = await _productRepository.GetWhereAsync(c => c.ProductCategory.CategoryId == categoryId);
            return BaseResponse<IList<ProductResponse>>.Success(_mapper.Map<IList<ProductResponse>>(products), 200);
        }

        public async Task<BaseResponse<IList<ProductResponse>>> GetProductsBySellerId(string sellerId)
        {
            var products = await _productRepository.GetWhereAsync(c => c.SellerId == sellerId);
            return BaseResponse<IList<ProductResponse>>.Success(_mapper.Map<IList<ProductResponse>>(products), 200);
        }

        public async Task<BaseResponse<ProductResponse>> UpdateProductCategory(ProductCategoryUpdateRequest productCategoryUpdateRequest)
        {
            var category = await _categoryRepository.GetByIdAsync(productCategoryUpdateRequest.CategoryId);

            if (category == null)
                return BaseResponse<ProductResponse>.Fail($"Category not found to Update ProductCategory. ProductId: '{productCategoryUpdateRequest.ProductId}', CategoryId: '{productCategoryUpdateRequest.CategoryId}'.", 400);

            var updateBuilder = new UpdateDefinitionBuilder<Product>()
                .Set(product => product.ProductCategory, new ProductCategory() { CategoryId = category.Id, CategoryName = category.Name })
                .Set(product => product.ModifiedOn, DateTime.UtcNow);

            var updatedProduct = await _productRepository.UpdateAndGetByIdAsync(productCategoryUpdateRequest.ProductId, updateBuilder);

            if (updatedProduct == null)
                return BaseResponse<ProductResponse>.Fail($"Failed to Update ProductCategory. ProductId: '{productCategoryUpdateRequest.ProductId}'.", 400);

            return BaseResponse<ProductResponse>.Success(_mapper.Map<ProductResponse>(updatedProduct), 200);
        }

        public async Task<BaseResponse<IList<UpdateProductCategoryResponse>>> UpdateProductCategories(List<string> categoryIdList)
        {
            var response = new List<UpdateProductCategoryResponse>();
            foreach (var categoryId in categoryIdList)
            {
                var category = await _categoryRepository.GetByIdAsync(categoryId);

                var updateBuilder = new UpdateDefinitionBuilder<Product>()
                .Set(product => product.ProductCategory, new ProductCategory() { CategoryId = category?.Id, CategoryName = category?.Name })
                .Set(product => product.ModifiedOn, DateTime.UtcNow);

                var result = await _productRepository.UpdateWhereAsync(product => product.ProductCategory.CategoryId == categoryId, updateBuilder);

                response.Add(new UpdateProductCategoryResponse() { CategoryId = categoryId, IsSuccess = result });
            }

            return BaseResponse<IList<UpdateProductCategoryResponse>>.Success(response, 200);
        }
    }
}
