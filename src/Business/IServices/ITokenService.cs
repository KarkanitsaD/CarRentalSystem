using System.Collections.Generic;
using System.Security.Claims;
using Data.Entities;

namespace Business.IServices
{
    public interface ITokenService
    {
        string GenerateToken(UserEntity user);
        RefreshTokenEntity GenerateRefreshToken();
        bool ValidateToken(string token);
        IEnumerable<Claim> GetClaims(string token);
    }
}