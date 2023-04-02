using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.Interfaces;
using UserService.Persistence.Contexts;
using UserService.Persistence.Repositories;

namespace UserService.Persistence
{
    public static class ServiceRegistration
    {
        public static void UserServicePersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddDbContext<ECommerceMicroserviceProjectDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection")));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();
        }
    }
}
