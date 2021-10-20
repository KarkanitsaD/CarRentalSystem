using Business.Interfaces;
using Business.MappingProfiles;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalServiceService, AdditionalServiceService>();
            services.AddScoped<IRentalPointService, RentalPointService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }

        public static IServiceCollection AddAutoMapperBusinessProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));

            return services;
        }
    }
}
