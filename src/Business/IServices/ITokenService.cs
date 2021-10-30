using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ITokenService
    {
        string GenerateJwt(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        Task ValidateRefreshTokenAsync(string refreshToken);
        Task CreateRefreshTokenAsync(Guid userId, string refreshToken);
        Task UpdateRefreshTokenAsync(Guid userId, string refreshToken);
    }
}