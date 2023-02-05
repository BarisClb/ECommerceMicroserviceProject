using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Request;
using ProductService.Infrastructure.Settings;
using SharedLibrary.Helpers;

namespace ProductService.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : CustomControllerBase
    {
        private readonly IProductService _productService;
        private readonly IOptions<DatabaseSettings> _conf;

        public ProductController(IProductService productService, IOptions<DatabaseSettings> conf)
        {
            _productService = productService;
            _conf = conf;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok(new { _conf.Value.DatabaseName, _conf.Value.CategoryCollectionName, _conf.Value.ProductCollectionName, _conf.Value.ConnectionString });
        }

        [HttpPost("createproduct")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequest productCreateRequest)
        {
            return Ok(await _productService.CreateProduct(productCreateRequest));
        }

        [HttpPut("updateproduct")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequest productUpdateRequest)
        {
            return Ok(await _productService.UpdateProduct(productUpdateRequest));
        }

        [HttpPost("deleteproduct")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            return Ok(await _productService.DeleteProduct(productId));
        }

        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("getproductbyid/{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            return Ok(await _productService.GetProductById(productId));
        }

        [HttpGet("getproductsbycategoryid/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(string categoryId)
        {
            return Ok(await _productService.GetProductsByCategoryId(categoryId));
        }

        [HttpGet("getproductsbysellerid/{sellerId}")]
        public async Task<IActionResult> GetProductsBySellerId(string sellerId)
        {
            return Ok(await _productService.GetProductsBySellerId(sellerId));
        }

        [HttpPut("updateproductcategory")]
        public async Task<IActionResult> UpdateProductCategory(ProductCategoryUpdateRequest productCategoryUpdateRequest)
        {
            return Ok(await _productService.UpdateProductCategory(productCategoryUpdateRequest));
        }

        [HttpPut("updateproductcategories")]
        public async Task<IActionResult> UpdateProductCategories(List<string> categoryIdList)
        {
            return Ok(await _productService.UpdateProductCategories(categoryIdList));
        }
    }
}
