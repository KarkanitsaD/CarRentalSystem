using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class JwtAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtTokenHandler _tokenHandler;

        public JwtAuthorizationMiddleware(RequestDelegate next, JwtTokenHandler tokenHandler)
        {
            _next = next;
            _tokenHandler = tokenHandler;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && _tokenHandler.ValidateToken(token))
                AttachUserRolesToContext(context, token);
            else
                context.Items["Authorized"] = false;

            await _next(context);
        }

        private void AttachUserRolesToContext(HttpContext context, string token)
        {
            var roles = _tokenHandler.GetClaimValues(token, ClaimTypes.Role);

            context.Items["Authorized"] = true;
            context.Items["UserRoles"] = roles;
        }
    }
}