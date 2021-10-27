using System;
using Data.Entities;

namespace Business.IServices
{
    public interface ITokenService
    {
        string GenerateToken(UserEntity user);
        RefreshTokenEntity GenerateRefreshToken(Guid userId);
    }
}