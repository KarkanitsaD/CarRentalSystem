using System;
using System.Collections.Generic;
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
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly SymmetricSecurityKey _symmetricSecurityKey;

        public JwtTokenHandler(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));

            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateToken(UserEntity userEntity)
        {
            var roleClaims = userEntity.Roles.Select(role => new Claim(ClaimTypes.Role, role.Title)).ToList();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userEntity.Id.ToString()),
                new Claim(ClaimTypes.Email, userEntity.Email),
                new Claim(ClaimTypes.Name, userEntity.Name),
            };
            claims.AddRange(roleClaims);

            var credentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_jwtOptions.TokenLifeTimeInSeconds),
                signingCredentials: credentials);

            return _tokenHandler.WriteToken(jwt);
        }

        public bool ValidateToken(string token)
        {
            try
            {
                _tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = _jwtOptions.ValidateIssuerSigningKey,
                    IssuerSigningKey = _symmetricSecurityKey,

                    ValidateIssuer = _jwtOptions.ValidateIssuer,
                    ValidIssuer = _jwtOptions.Issuer,

                    ValidateAudience = _jwtOptions.ValidateAudience,
                    ValidAudience = _jwtOptions.Audience,

                    ValidateLifetime = _jwtOptions.ValidateLifetime,
                    ClockSkew = TimeSpan.Zero
                }, out _);
            }
            catch
            {
                return false;
            }
            return true;
        }
            
        public string GetClaimValue(string token, string claimType)
        {
            var securityToken = _tokenHandler.ReadJwtToken(token);

            var claimValue = securityToken.Claims.First(claim => claim.Type == claimType).Value;

            return claimValue;
        }

        public IEnumerable<string> GetClaimValues(string token, string claimType)
        {
            var securityToken = _tokenHandler.ReadJwtToken(token);

            var claimValues = securityToken.Claims.Where(claim => claim.Type == claimType)
                    .Select(claim => claim.Value);

            return claimValues;
        }
    }
}