using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class RefreshTokenRepository : BaseRepository<RefreshTokenEntity>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}