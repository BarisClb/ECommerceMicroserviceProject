using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Requests;
using SharedLibrary.Helpers;

namespace ProductService.WebAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("getAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpGet("getCategoryById/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(string categoryId)
        {
            return Ok(await _categoryService.GetCategoryById(categoryId));
        }

        [HttpGet("getCategoriesByParentCategoryId/{parentId}")]
        public async Task<IActionResult> GetCategoriesByParentCategoryId(string parentId)
        {
            return Ok(await _categoryService.GetCategoriesByParentCategoryId(parentId));
        }

        [HttpPost("createCategory")]
        public async Task<IActionResult> CreateCategory(CategoryCreateRequest categoryCreateRequest)
        {
            return Ok(await _categoryService.CreateCategory(categoryCreateRequest));
        }

        [HttpPut("updateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest)
        {
            return Ok(await _categoryService.UpdateCategory(categoryUpdateRequest));
        }

        [HttpPost("deleteCategory")]
        public async Task<IActionResult> DeleteCategory(string categoryId)
        {
            return Ok(await _categoryService.DeleteCategory(categoryId));
        }
    }
}
