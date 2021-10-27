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
            return await DbSet.AsQueryable().FirstOrDefaultAsync(t => t.UserId == userId);
        }

        public async Task<RefreshTokenEntity> GetByAsync(string token)
        {
            return await DbSet.AsQueryable().Include(t => t.User).ThenInclude(u => u.Roles).FirstOrDefaultAsync(t => t.Token == token);
        }
    }
}