using Business;
using Business.Helpers;
using Business.IServices;
using Business.Services;
using Data.IRepositories;
using Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRentalPointRepository, RentalPointRepository>();
            services.AddScoped<IAdditionalFacilityRepository, AdditionalFacilityRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAdditionalFacilityService, AdditionalFacilityService>();
            services.AddScoped<IRentalPointService, RentalPointService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }

        public static IServiceCollection AddJwtOptions(this IServiceCollection services)
        {
            return services.Configure<JwtOptions>(new ConfigurationBuilder().AddJsonFile("jwtsettings.json").Build());
        }
        public static IServiceCollection AddJwtTokenHandler(this IServiceCollection services)
        {
            return services.AddSingleton<JwtTokenHandler>();
        }
    }
}