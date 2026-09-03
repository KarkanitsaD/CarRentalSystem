using Microsoft.IdentityModel.Tokens;

namespace Business.Options
{
    public class JwtOptions
    {
        public const string Jwt = "Jwt";
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifeTimeInSeconds { get; set; }
        public int RefreshTokenLifeTimeInSeconds { get; set; }
        public SymmetricSecurityKey SymmetricSecurityKey =>
            new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(SecretKey));
    }
}