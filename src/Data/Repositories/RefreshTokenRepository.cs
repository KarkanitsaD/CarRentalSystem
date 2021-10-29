using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RefreshTokenRepository : BaseRepository<RefreshTokenEntity>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }

        public async Task<RefreshTokenEntity> GetByAsync(Guid userId)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.UserId == userId);
        }

        public async Task<RefreshTokenEntity> GetByAsync(string token)
        {
            return await DbSet.Include(t => t.User).FirstOrDefaultAsync(t => t.Token == token);
        }
    }
}