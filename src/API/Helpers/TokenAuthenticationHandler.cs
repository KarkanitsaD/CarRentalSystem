using System.Linq;
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
    public class AuthenticationOptions : AuthenticationSchemeOptions
    {
    }

    public class TokenAuthenticationHandler : AuthenticationHandler<AuthenticationOptions>
    {
        private readonly ITokenService _tokenService;

        //бесполезные 4 аргумента, которые я вообще не использую. Они требуются для базового конструктора.
        //я до этого вместо этого класса делал свой middleware аутентификации в старых коммитах есть, но я не знаю как клеймсы засунуть в контекст, чтобы атрибут [Authorize] их считывал
        //поэтому я нашел этот класс и методы AuthenticateResult.Success, AuthenticateResult.Fail
        //еще в каждом атрибуте [Authorize] в контроллерах нужно будет указывать кастомное имя схемы
        public TokenAuthenticationHandler(IOptionsMonitor<AuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ITokenService tokenService) : base(options, logger, encoder, clock)
        {
            _tokenService = tokenService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null && _tokenService.IsTokenValid(token))
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
