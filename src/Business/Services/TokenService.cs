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
using Business.Options;
using Data.Entities;
using Data.IRepositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public TokenService(IOptions<JwtOptions> jwtOptions, IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _jwtOptions = jwtOptions.Value;
        }

        public string GenerateJwt(IEnumerable<Claim> claims)
        {
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

        public string GenerateRefreshToken()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }

        public async Task ValidateRefreshTokenAsync(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetByAsync(refreshToken);

            if (token == null)
            {
                throw new NotFoundException("Token is not found");
            }

            if (DateTime.Now > token.ExpirationTime)
            {
                await _refreshTokenRepository.DeleteAsync(token);
                throw new BadRequestException("Refresh token expired.");
            }
        }

        public async Task CreateRefreshTokenAsync(Guid userId, string refreshToken)
        {
            var token = new RefreshTokenEntity
            {
                UserId = userId,
                Token = refreshToken,
                ExpirationTime = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenLifeTimeInSeconds)
            };

            await _refreshTokenRepository.CreateAsync(token);
        }

        public async Task UpdateRefreshTokenAsync(Guid userId, string refreshToken)
        {
            var tokenToUpdate = await _refreshTokenRepository.GetByAsync(userId);

            tokenToUpdate.Token = refreshToken;
            tokenToUpdate.ExpirationTime = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenLifeTimeInSeconds);

            await _refreshTokenRepository.UpdateAsync(tokenToUpdate);
        }

        public Claim GetClaimFromJwt(string jwt, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwt);
            var claim = token.Claims.First(c => c.Type == claimType);
            return claim;
        }
    }
}