using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Business.IServices;
using Data.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services
{
    public class TokenServices : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenServices(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string GenerateToken(UserEntity user)
        {
            var roleClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Title)).ToList();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
            };
            claims.AddRange(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));

            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_jwtOptions.TokenLifeTimeInSeconds),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public RefreshTokenEntity GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomNumber);
            var token = Convert.ToBase64String(randomNumber);

            var refreshToken = new RefreshTokenEntity
            {
                CreationTime = DateTime.Now,
                Token = token,
                IsRevoked = false
            };

            return refreshToken;
        }

        public bool ValidateToken(string token)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));

            try
            {
                new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = _jwtOptions.ValidateIssuerSigningKey,
                    IssuerSigningKey = symmetricSecurityKey,

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

        public IEnumerable<Claim> GetClaims(string token)
        {
            var securityToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

            return securityToken.Claims.ToArray();
        }
    }
}