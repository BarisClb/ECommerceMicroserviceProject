using AutoMapper;
using MongoDB.Driver;
using ProductService.Application.Interfaces;
using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;
using ProductService.Domain.Entities;
using SharedLibrary.Models;

namespace ProductService.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<CategoryCreateRequest>> CreateCategory(CategoryCreateRequest categoryCreateRequest)
        {
            var category = _mapper.Map<Category>(categoryCreateRequest);

            category.CreatedOn = DateTime.UtcNow;
            await _categoryRepository.InsertAsync(category);
            return BaseResponse<CategoryCreateRequest>.Success(categoryCreateRequest, 201);
        }

        public async Task<BaseResponse<CategoryResponse>> UpdateCategory(CategoryUpdateRequest categoryUpdateRequest)
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
                return BaseResponse<CategoryResponse>.Fail($"No values provided to Update Category. CategoryId: '{categoryUpdateRequest.Id}'.", 400);

            categoryUpdates.Add(categoryUpdateBuilder.Set(c => c.ModifiedOn, DateTime.UtcNow));
            var updatedCategory = await _categoryRepository.UpdateAndGetByIdAsync(categoryUpdateRequest.Id, categoryUpdateBuilder.Combine(categoryUpdates));

            if (updatedCategory == null)
                return BaseResponse<CategoryResponse>.Fail($"Failed to Update Category. CategoryId: '{categoryUpdateRequest.Id}'.", 500);

            //if (updateProductCategoryEvent)
            //Trigger ProductService/UpdateProductCategories

            return BaseResponse<CategoryResponse>.Success(_mapper.Map<CategoryResponse>(updatedCategory), 200);
        }

        public async Task<BaseResponse<NoContent>> DeleteCategory(string categoryId)
        {
            var result = await _categoryRepository.DeleteByIdAsync(categoryId);

            if (!result)
                return BaseResponse<NoContent>.Fail($"Failed to Delete Category. CategoryId: '{categoryId}'.", 400);

            return BaseResponse<NoContent>.Success(204);
        }

        public async Task<BaseResponse<IList<CategoryResponse>>> GetAllCategories()
        {
            var categories = (await _categoryRepository.GetWhereAsync(c => true));
            return BaseResponse<IList<CategoryResponse>>.Success(_mapper.Map<IList<CategoryResponse>>(categories), 200);
        }

        public async Task<BaseResponse<CategoryResponse>> GetCategoryById(string categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return BaseResponse<CategoryResponse>.Success(_mapper.Map<CategoryResponse>(category), 200);
        }

        public async Task<BaseResponse<IList<CategoryResponse>>> GetCategoriesByParentCategoryId(string categoryId)
        {
            var categories = (await _categoryRepository.GetWhereAsync(c => c.ParentCategoryId == categoryId));
            return BaseResponse<IList<CategoryResponse>>.Success(_mapper.Map<IList<CategoryResponse>>(categories), 200);
        }
    }
}
