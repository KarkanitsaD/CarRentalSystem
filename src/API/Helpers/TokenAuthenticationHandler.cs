﻿using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Business;
using Business.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API.Helpers
{
    public class TokenAuthenticationHandler : AuthenticationHandler<JwtOptions>
    {
        private readonly ITokenService _tokenService;

        public TokenAuthenticationHandler(IOptionsMonitor<JwtOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ITokenService tokenService) : base(options, logger, encoder, clock)
        {
            _tokenService = tokenService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && _tokenService.ValidateToken(token))
            {
                var claims = _tokenService.GetClaims(token);
                var claimsIdentity = new ClaimsIdentity(claims);
                var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), this.Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }

            return Task.FromResult(AuthenticateResult.Fail($"Balancer not authorize token : for token = {token}"));
        }
    }
}