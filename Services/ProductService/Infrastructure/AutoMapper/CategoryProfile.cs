using AutoMapper;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryCreateRequest>().ReverseMap();
            CreateMap<Category, CategoryUpdateRequest>().ReverseMap();
            CreateMap<Category, CategoryResponse>().ReverseMap();
        }
    }
}
