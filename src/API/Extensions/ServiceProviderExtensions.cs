﻿using Business.Helpers;
using Business.IServices;
using Business.Services;
using Data.IRepositories;
using Data.Repositories;
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
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRentalPointRepository, RentalPointRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ICarPictureRepository, CarPictureRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRentalPointService, RentalPointService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICarPictureService, CarPictureService>();

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsOptions.CorsOptions.ApiCorsName,
                    builder =>
                    {
                        builder.WithOrigins(CorsOptions.CorsOptions.WebApp)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }

        public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
        {
            return services.AddScoped<PasswordHasher>();
        }
    }
}