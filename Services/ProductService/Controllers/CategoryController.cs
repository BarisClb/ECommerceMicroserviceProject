using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Request;
using ProductService.Infrastructure.Settings;
using SharedLibrary.Helpers;

namespace ProductService.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IOptions<DatabaseSettings> _conf;

        public CategoryController(ICategoryService categoryService, IOptions<DatabaseSettings> conf)
        {
            _categoryService = categoryService;
            _conf = conf;
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok(new { _conf.Value.DatabaseName, _conf.Value.CategoryCollectionName, _conf.Value.ProductCollectionName, _conf.Value.ConnectionString });
        }

        [HttpPost("createcategory")]
        public async Task<IActionResult> CreateCategory(CategoryCreateRequest categoryCreateRequest)
        {
            return Ok(await _categoryService.CreateCategory(categoryCreateRequest));
        }

        [HttpPut("updatecategory")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest)
        {
            return Ok(await _categoryService.UpdateCategory(categoryUpdateRequest));
        }

        [HttpPost("deletecategory")]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            return Ok(await _categoryService.DeleteCategory(categoryId));
        }

        [HttpGet("getallcategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet("getcategorybyid/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            return Ok(await _categoryService.GetCategoryById(categoryId));
        }

        [HttpGet("getcategoriesbyparentcategoryid/{categoryId}")]
        public async Task<IActionResult> GetCategoriesByParentCategoryId(string categoryId)
        {
            return Ok(await _categoryService.GetCategoriesByParentCategoryId(categoryId));
        }
    }
}
