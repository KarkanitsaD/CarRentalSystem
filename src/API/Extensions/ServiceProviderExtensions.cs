using System;
using System.Text;
using Business;
using Business.Helpers;
using Business.IServices;
using Business.Services;
using Data.IRepositories;
using Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

        public static IServiceCollection AddJwtTokenHandler(this IServiceCollection services)
        {
            return services.AddSingleton<JwtTokenHandler>();
        }

        public static void AddJwtAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
        {
            services.AddAuthentication(settings =>
            {
                settings.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                settings.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(settings =>
            {
                settings.RequireHttpsMetadata = false;
                settings.SaveToken = true;
                settings.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey)),

                    ValidateIssuer = jwtOptions.ValidateIssuer,
                    ValidIssuer = jwtOptions.Issuer,

                    ValidateAudience = jwtOptions.ValidateAudience,
                    ValidAudience = jwtOptions.Audience,

                    ValidateLifetime = jwtOptions.ValidateLifetime,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}