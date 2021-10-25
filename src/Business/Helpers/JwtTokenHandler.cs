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
    }
}