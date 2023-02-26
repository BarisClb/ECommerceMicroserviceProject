using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserService.Application.Interfaces;
using UserService.Persistence.Contexts;
using UserService.Persistence.Repositories;

namespace UserService
{
    public static class ServiceRegistration
    {
        public static void UserServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddDbContext<ECommerceMicroserviceProjectDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MsSqlConnection")));
            services.AddAutoMapper(assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();
        }
    }
}
