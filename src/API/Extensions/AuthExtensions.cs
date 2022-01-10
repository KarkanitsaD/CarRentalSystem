using System;
using Business.Options;
using Business.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class AuthExtensions
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtOptions.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = jwtOptions.SymmetricSecurityKey,
                        ValidateIssuerSigningKey = true,

                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public static void AddAuthorizationService(this IServiceCollection services)
        {
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy(Policy.ForAdminOnly, policy =>
                    policy.RequireRole(Policy.ForAdminOnly));

                opts.AddPolicy(Policy.ForUserOnly, policy =>
                    policy.RequireRole(Policy.ForUserOnly));
            });
        }
    }
}