using Business.Policies;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class AuthorizationExtensions
    {
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