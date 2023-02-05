using Microsoft.Extensions.Options;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Settings;
using ProductService.Persistence.Interfaces;

namespace ProductService.Persistence.Repositories
{
    public class ProductRepository : MongoRepository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings.Value.ConnectionString, databaseSettings.Value.DatabaseName, databaseSettings.Value.ProductCollectionName)
        { }
    }
}
