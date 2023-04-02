using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    { }
}
