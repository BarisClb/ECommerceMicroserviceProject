using Microsoft.Extensions.Options;
using ProductService.Application.Interfaces;
using ProductService.Application.Settings;
using ProductService.Domain.Entities;

namespace ProductService.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings.Value.ConnectionString, databaseSettings.Value.DatabaseName, databaseSettings.Value.ProductCollectionName)
        { }
    }
}
