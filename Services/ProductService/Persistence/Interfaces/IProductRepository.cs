using ProductService.Domain.Entities;

namespace ProductService.Persistence.Interfaces
{
    public interface IProductRepository : IMongoRepository<Product>
    { }
}
