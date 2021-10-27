using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class JwtAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthorizationMiddleware(RequestDelegate next, ITokenService tokenService)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && tokenService.IsTokenValid(token))
            {
                var claims = tokenService.GetClaims(token);
                foreach (var claim in claims)
                {
                    context.User.Claims.Append(claim);
                }


                await context.AuthenticateAsync();
            }
            
            await _next(context);
        }
    }
}
