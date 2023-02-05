using ProductService.Domain.Entities;

namespace ProductService.Persistence.Interfaces
{
    public interface ICategoryRepository : IMongoRepository<Category>
    { }
}
