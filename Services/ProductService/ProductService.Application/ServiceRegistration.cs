using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Application.Interfaces;
using ProductService.Application.Services;
using ProductService.Application.Settings;

namespace ProductService.Application
{
    public static class ServiceRegistration
    {
        public static void ProductServiceApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, Application.Services.ProductService>();
        }
    }
}
