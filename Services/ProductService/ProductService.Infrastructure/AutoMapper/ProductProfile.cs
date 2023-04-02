using AutoMapper;
using ProductService.Application.Models.Requests;
using ProductService.Application.Models.Responses;
using ProductService.Domain.Entities;

namespace ProductService.Infrastructure.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductCreateRequest>().ReverseMap();
            CreateMap<Product, ProductUpdateRequest>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}
