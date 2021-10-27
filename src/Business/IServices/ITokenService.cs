using Data.Entities;

namespace Business.IServices
{
    public interface ITokenService
    {
        string GenerateToken(UserEntity user);
        string GenerateRefreshToken(UserEntity user);
    }
}