using AutoMapper;
using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;
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
