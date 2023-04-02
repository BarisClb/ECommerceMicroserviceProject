using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ProductServiceInfrastructureServiceRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
        }
    }
}
