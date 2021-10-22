using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Helpers
{
    public class JwtTokenHandler
    {
        private readonly JwtOptions _jwtOptions;
        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();

        public JwtTokenHandler(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string GenerateToken(UserEntity userEntity)
        {
            var claims = userEntity.Roles.Select(role => new Claim(role.Title, "true"))
                .Append(new Claim("UserId", userEntity.Id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddSeconds(int.Parse(_jwtOptions.TokenLifeTimeInSeconds)),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                _tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _jwtOptions.Issuer,
                    ValidAudience = _jwtOptions.Audience,
                    IssuerSigningKey = GetSymmetricSecurityKey()
                }, out _);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public object GetClaim(string token, string claimType)
        {
            var securityToken = _tokenHandler.ReadJwtToken(token);

            var claimValue = securityToken.Claims.Select(claim => claim.Type == claimType);

            return claimValue;
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));
        }
    }
}