using System;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshTokenEntity>
    {
        Task<RefreshTokenEntity> GetByAsync(Guid userId);
        Task<RefreshTokenEntity> GetByAsync(string token);
    }
}