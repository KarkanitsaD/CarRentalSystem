using System;
using System.Linq;
using System.Threading.Tasks;
using Business.IServices;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class JwtAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ITokenService tokenService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && tokenService.ValidateToken(token))
                throw new Exception("Validated.");

            await _next(context);
        }
    }
}