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
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public TokenService(IOptions<JwtOptions> options)
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
            var base64Payload = token.Split('.')[1];

            var payloadString = new StringBuilder(Base64Decode(base64Payload));

            var claimsString = payloadString.ToString().Split(',');

            var idClaimString = claimsString.First(c => c.Contains("\"" + ClaimTypes.NameIdentifier +"\""));
            var idClaimValue = idClaimString.Split(':')[1].Replace("\"", "");
            var idClaim = new Claim(ClaimTypes.NameIdentifier, idClaimValue, ClaimValueTypes.String);

            var rolesClaimString = claimsString.First(c => c.Contains("\"" + ClaimTypes.Role + "\""));
            var rolesClaimValues = rolesClaimString.Split(':')[1].Replace("\"", "").Split(',');

            var rolesClaims = new List<Claim>();
            foreach (var cl in rolesClaimValues)
            {
                rolesClaims.Add(new Claim(ClaimTypes.Role, cl, ClaimValueTypes.String));
            }

            var allClaims = new List<Claim>(rolesClaims).Append(idClaim);

            return allClaims;
        }

        public string GetToken(UserEntity user)
        {
            var jsonHeader = new StringBuilder("{\"alg\":\"HS256\",\"typ\":\"JWT\"}");

            var jsonPayload = new StringBuilder("{")
                .Append(GetJsonClaim(ClaimTypes.NameIdentifier, user.Id.ToString()))
                .Append(',')
                .Append(GetJsonClaim(ClaimTypes.Email, user.Email))
                .Append(',')
                .Append(GetJsonClaim("exp", DateTimeOffset.UtcNow.ToUnixTimeSeconds() + _jwtOptions.TokenLifeTimeInSeconds))
                .Append(',');

            if (user.Roles.Count == 1)
            {
                jsonPayload.Append(GetJsonClaim(ClaimTypes.Role, user.Roles.ElementAt(0).Title));
            }
            else
            {
                var rolesClaim = new StringBuilder("\"" + ClaimTypes.Email + "\"" + ":[");

                for (int i = 0; i < user.Roles.Count - 1; i++)
                {
                    rolesClaim.Append("\"").Append(user.Roles.ElementAt(i).Title).Append("\"").Append(",");
                }
                rolesClaim.Append("\"").Append(user.Roles.ElementAt(user.Roles.Count - 1).Title).Append("\"").Append("]");

                jsonPayload.Append(rolesClaim);
            }

            jsonPayload.Append("}");

            var base64Header = Base64Encode(jsonHeader.ToString());
            var base64Payload = Base64Encode(jsonPayload.ToString());

            var secretKeyInBytes = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            var base64HeaderAndPayloadInBytes = Encoding.UTF8.GetBytes(base64Header + '.' + base64Payload);

            using HMACSHA256 hmacsha256 = new HMACSHA256(secretKeyInBytes);
            var signature = Convert.ToBase64String(hmacsha256.ComputeHash(base64HeaderAndPayloadInBytes))
                .Replace("-", "");

            var jwt = base64Header + '.' + base64Payload + '.' + signature;

            return jwt;
        }

        private string GetJsonClaim(string name, string value)
        {
            return "\"" + name + "\"" + ":" + "\"" + value + "\"";
        }

        private string GetJsonClaim(string name, long value)
        {
            return "\"" + name + "\"" + ":" + value;
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public bool IsTokenValid(string token)
        {
            var tokenParts = token.Split('.');

            var base64Header = tokenParts[0];
            var base64Payload = tokenParts[1];
            var signature = tokenParts[2];

            var secretKeyInBytes = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            var headerAndPayloadInBytes = Encoding.UTF8.GetBytes(base64Header + '.' + base64Payload);

            using HMACSHA256 hmacsha256 = new HMACSHA256(secretKeyInBytes);
            var expectedSignature = Convert.ToBase64String(hmacsha256.ComputeHash(headerAndPayloadInBytes)).Replace("-", "");

            if (expectedSignature != signature)
                return false;

            var payloadString = new StringBuilder(Base64Decode(base64Payload));
            payloadString.Replace("{", "")
                .Replace("}", "");

            var claimsString = payloadString.ToString().Split(',');
            var expireClaimValue = int.Parse(claimsString.First(claim => claim.StartsWith("\"exp\":")).Split(':')[1]);

            var tokenCreationTime = DateTimeOffset.FromUnixTimeSeconds(expireClaimValue).ToUnixTimeSeconds();

            if (tokenCreationTime + _jwtOptions.TokenLifeTimeInSeconds < DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                return false;

            return true;
        }
    }
}