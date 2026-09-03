using API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}