using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IRefreshTokenRepository : IBaseRepository<RefreshTokenEntity>
    {
        Task<RefreshTokenEntity> Get(string token);
    }
}
