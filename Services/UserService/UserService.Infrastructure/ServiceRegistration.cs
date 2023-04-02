using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void UserServiceInfrastructureServiceRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
        }
    }
}
