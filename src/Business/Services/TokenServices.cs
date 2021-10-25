using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.IRepositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services
{
    public class TokenServices : ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtOptions _jwtOptions;

        public TokenServices(IUserRepository userRepository, IOptions<JwtOptions> options)
        {
            _userRepository = userRepository;
            _jwtOptions = options.Value;
        }

        public async Task<string> GenerateToken(AuthenticateRequestModel requestModel)
        {
            var user = await _userRepository.GetByEmailAndPassword(requestModel.Email, requestModel.Password);

            if(user == null)
                throw new NotAuthenticatedException("User with this credentials not found.");

            var roleClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Title)).ToList();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
            };
            claims.AddRange(roleClaims);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey));

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
            var tokenParts = token.Split(".");
            var header = tokenParts[0];
            var payload = tokenParts[1];
            var signature = tokenParts[2];

            var secretKey = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);
            var headerAndPayload = Encoding.UTF8.GetBytes(header + "." + payload);

            HMACSHA256 hmacsha256 = new HMACSHA256(secretKey);
            var expectedSignature = Convert.ToBase64String(hmacsha256.ComputeHash(headerAndPayload)).Replace("-", "");
            expectedSignature = expectedSignature.Replace("+", "-");

            var payloadClaims = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(payload)).Replace("-", "").Replace("{", "").Replace("}", "").Split(',');
            var expireClaimValue = int.Parse(payloadClaims.First(claim => claim.StartsWith("\"exp\":")).Split(':')[1]);

            var tokenTime = DateTimeOffset.FromUnixTimeSeconds(expireClaimValue).LocalDateTime;

            if (tokenTime < DateTime.Now)
                return false;

            return true;
        }
    }
}