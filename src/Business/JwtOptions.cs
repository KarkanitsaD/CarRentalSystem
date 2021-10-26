using Microsoft.AspNetCore.Authentication;

namespace Business
{
    public class JwtOptions : AuthenticationSchemeOptions
    {
        public const string Jwt = "Jwt";
        public string SecretKey { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public string Issuer { get; set; }
        public bool ValidateIssuer { get; set; }
        public string Audience { get; set; }
        public bool ValidateAudience { get; set; }
        public int TokenLifeTimeInSeconds { get; set; }
        public bool ValidateLifetime { get; set; }
        public int RefreshTokenLifeTimeInSeconds { get; set; }
    }
}
