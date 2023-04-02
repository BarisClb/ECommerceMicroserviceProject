using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Requests;
using SharedLibrary.Helpers;

namespace ProductService.WebAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("getProductById/{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            return Ok(await _productService.GetProductById(productId));
        }

        [HttpGet("getProductsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(string categoryId)
        {
            return Ok(await _productService.GetProductsByCategoryId(categoryId));
        }

        [HttpGet("getProductsBySellerId/{sellerId}")]
        public async Task<IActionResult> GetProductsBySellerId(string sellerId)
        {
            return Ok(await _productService.GetProductsBySellerId(sellerId));
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest productCreateRequest)
        {
            return Ok(await _productService.CreateProduct(productCreateRequest));
        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            return Ok(await _productService.UpdateProduct(productUpdateRequest));
        }

        [HttpPut("updateProductCategory")]
        public async Task<IActionResult> UpdateProductCategory(ProductCategoryUpdateRequest productCategoryUpdateRequest)
        {
            return Ok(await _productService.UpdateProductCategory(productCategoryUpdateRequest));
        }

        [HttpPut("updateProductCategories")]
        public async Task<IActionResult> UpdateProductCategories(List<string> categoryIdList)
        {
            return Ok(await _productService.UpdateProductCategories(categoryIdList));
        }

        [HttpPost("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            return Ok(await _productService.DeleteProduct(productId));
        }
    }
}
