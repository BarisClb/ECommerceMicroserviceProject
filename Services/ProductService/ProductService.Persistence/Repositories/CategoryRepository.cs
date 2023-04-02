using Microsoft.Extensions.Options;
using ProductService.Application.Interfaces;
using ProductService.Application.Settings;
using ProductService.Domain.Entities;

namespace ProductService.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings.Value.ConnectionString, databaseSettings.Value.DatabaseName, databaseSettings.Value.CategoryCollectionName)
        { }
    }
}
