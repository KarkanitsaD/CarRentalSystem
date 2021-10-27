using API.Middleware;
using Business.Contracts;
using Business.IServices;
using Business.Services;
using Data.IRepositories;
using Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
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
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }

        public static void AddAuthorizationWithPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
                options.AddPolicy(Policies.UserPolicy, policy => policy.Combine(new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                    .RequireRole(Policies.UserPolicy)
                    .Build())));
        }

        public static IApplicationBuilder UseJwtAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtAuthorizationMiddleware>();
        }
    }
}