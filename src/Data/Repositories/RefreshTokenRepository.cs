using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RefreshTokenRepository : BaseRepository<RefreshTokenEntity>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(ApplicationContext context)
            : base(context)
        {
        }

        public async Task<RefreshTokenEntity> Get(string token)
        {
            return await DbSet.Include(t => t.User).FirstOrDefaultAsync(t => t.Token == token);
        }
    }
}