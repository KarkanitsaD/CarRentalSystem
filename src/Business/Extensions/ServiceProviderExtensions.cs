using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static  class ServiceProviderExtensions
    {
        public static IServiceCollection AddBusinessMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceProviderExtensions));

            return services;
        }
    }
}