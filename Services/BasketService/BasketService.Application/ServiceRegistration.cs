using BasketService.Application.Repositories;
using BasketService.Application.Services;
using BasketService.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Application
{
    public static class ServiceRegistration
    {
        public static void BasketServiceApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = $"{configuration.GetValue<string>("RedisSettings:Host")}:{configuration.GetValue<string>("RedisSettings:Port")},password={configuration.GetValue<string>("RedisSettings:Password")}";
            });
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IBasketService, Services.BasketService>();
        }
    }
}
