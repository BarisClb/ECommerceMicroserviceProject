﻿using ProductService.Application.Interfaces;
using ProductService.Application.Services;
using ProductService.Infrastructure.Settings;
using ProductService.Persistence.Interfaces;
using ProductService.Persistence.Repositories;
using System.Reflection;

namespace ProductService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ProductServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, Application.Services.ProductService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
