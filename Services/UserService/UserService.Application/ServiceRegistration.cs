using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserService.Application
{
    public static class ServiceRegistration
    {
        public static void UserServiceApplicationServiceRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
