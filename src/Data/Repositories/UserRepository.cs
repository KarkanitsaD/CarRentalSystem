using System;
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
            return await DbSet.Include(user => user.Role).Include(user => user.RefreshToken)
                .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == password);
        }

        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            return await DbSet
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<UserEntity> GetByRefreshTokenAsync(string refreshToken)
        {
            return await DbSet.Include(u => u.RefreshToken).Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.RefreshToken.Token == refreshToken);
        }


        public override async Task<PageResult<UserEntity>> GetPageListAsync(QueryParameters<UserEntity> queryParameters)
        {
            var query = DbSet.AsQueryable();

            query = BaseQuery(query, queryParameters);

            int totalItemsCount = await query.CountAsync();

            if (queryParameters.PaginationRule != null)
            {
                query = PaginationQuery(query, queryParameters.PaginationRule);
            }

            query = query.Include(u => u.Role);

            var items = await query.ToListAsync();

            return new PageResult<UserEntity>(items, totalItemsCount);
        }

        public override Task<UserEntity> GetAsync(Guid id)
        {
            return DbSet.Include(user => user.Role).FirstOrDefaultAsync(user => user.Id == id);
        }
    }
}