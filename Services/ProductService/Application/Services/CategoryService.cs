using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
using ProductService.Domain.Entities;
using ProductService.Persistence.Interfaces;
using SharedLibrary.Models;

namespace ProductService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _autoMapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper autoMapper)
        {
            _categoryRepository = categoryRepository;
            _autoMapper = autoMapper;
        }


        public async Task<Response<CategoryCreateRequest>> CreateCategory(CategoryCreateRequest categoryCreateRequest)
        {
            var category = _autoMapper.Map<Category>(categoryCreateRequest);

            category.CreatedOn = DateTime.UtcNow;
            await _categoryRepository.InsertAsync(category);
            return Response<CategoryCreateRequest>.Success(categoryCreateRequest, 201);
        }

        public async Task<Response<CategoryResponse>> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest)
        {
            var categoryUpdateBuilder = Builders<Category>.Update;
            var categoryUpdates = new List<UpdateDefinition<Category>>();
            bool updateProductCategoryEvent = false;

            if (!string.IsNullOrEmpty(categoryUpdateRequest.Name))
            {
                categoryUpdates.Add(categoryUpdateBuilder.Set(c => c.Name, categoryUpdateRequest.Name));
                updateProductCategoryEvent = true;
            }
            if (!string.IsNullOrEmpty(categoryUpdateRequest.Description))
                categoryUpdates.Add(categoryUpdateBuilder.Set(c => c.Description, categoryUpdateRequest.Description));
            if (!string.IsNullOrEmpty(categoryUpdateRequest.ParentCategoryId))
                categoryUpdates.Add(categoryUpdateBuilder.Set(c => c.ParentCategoryId, categoryUpdateRequest.ParentCategoryId));

            if (categoryUpdates.Count == 0)
                return Response<CategoryResponse>.Fail($"No values provided to Update Category. CategoryId: '{categoryUpdateRequest.Id}'.", 400);

            categoryUpdates.Add(categoryUpdateBuilder.Set(c => c.ModifiedOn, DateTime.UtcNow));
            var updatedCategory = await _categoryRepository.UpdateAndGetByIdAsync(categoryUpdateRequest.Id, categoryUpdateBuilder.Combine(categoryUpdates));

            if (updatedCategory == null)
                return Response<CategoryResponse>.Fail($"Failed to Update Category. CategoryId: '{categoryUpdateRequest.Id}'.", 500);

            //if (updateProductCategoryEvent)
            //Trigger ProductService/UpdateProductCategories

            return Response<CategoryResponse>.Success(_autoMapper.Map<CategoryResponse>(updatedCategory), 200);
        }

        public async Task<Response<NoContent>> DeleteCategory(string categoryId)
        {
            var result = await _categoryRepository.DeleteByIdAsync(categoryId);

            if (!result)
                return Response<NoContent>.Fail($"Failed to Delete Category. CategoryId: '{categoryId}'.", 400);

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<IList<CategoryResponse>>> GetAllCategories()
        {
            var categories = (await _categoryRepository.GetWhereAsync(c => true));
            return Response<IList<CategoryResponse>>.Success(_autoMapper.Map<List<CategoryResponse>>(categories), 200);
        }

        public async Task<Response<CategoryResponse>> GetCategoryById(string categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return Response<CategoryResponse>.Success(_autoMapper.Map<CategoryResponse>(category), 200);
        }

        public async Task<Response<IList<CategoryResponse>>> GetCategoriesByParentCategoryId(string categoryId)
        {
            var categories = (await _categoryRepository.GetWhereAsync(c => c.ParentCategoryId == categoryId));
            return Response<IList<CategoryResponse>>.Success(_autoMapper.Map<List<CategoryResponse>>(categories), 200);
        }
    }
}
