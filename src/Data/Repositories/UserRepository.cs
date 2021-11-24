using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(CarRentalSystemContext context)
            : base(context)
        {
        }

        public async Task<UserEntity> GetByCredentialsAsync(string email, string password)
        {
            return await DbSet.Include(user => user.Roles).Include(user => user.RefreshToken)
                .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == password);
        }

        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            return await DbSet
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<UserEntity> GetByRefreshTokenAsync(string refreshToken)
        {
            return await DbSet.Include(u => u.RefreshToken).Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.RefreshToken.Token == refreshToken);
        }

        public override async Task<List<UserEntity>> GetListAsync(QueryParameters<UserEntity> queryParameters = null)
        {
            var query = DbSet.AsQueryable();

            if (queryParameters == null)
            {
                return await query.Include(u => u.Roles).ToListAsync();
            }

            query = BaseQuery(query, queryParameters);

            query.Include(u => u.Roles);

            return await query.ToListAsync();
        }
    }
}