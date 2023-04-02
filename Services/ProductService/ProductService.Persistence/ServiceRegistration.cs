using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interfaces;
using ProductService.Persistence.Repositories;

namespace ProductService.Persistence
{
    public static class ServiceRegistration
    {
        public static void ProductServicePersistenceServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
