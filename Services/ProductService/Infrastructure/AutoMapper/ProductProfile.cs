using AutoMapper;
using ProductService.Application.Models.Request;
using ProductService.Application.Models.Response;
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
