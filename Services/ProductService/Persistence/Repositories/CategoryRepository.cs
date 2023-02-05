using Microsoft.Extensions.Options;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Settings;
using ProductService.Persistence.Interfaces;

namespace ProductService.Persistence.Repositories
{
    public class CategoryRepository : MongoRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings.Value.ConnectionString, databaseSettings.Value.DatabaseName, databaseSettings.Value.CategoryCollectionName)
        { }
    }
}
