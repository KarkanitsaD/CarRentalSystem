using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Data.Query.FiltrationModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(CarRentalSystemContext context)
            : base(context)
        {
        }
        public override Task<UserEntity> GetAsync(Guid id)
        {
            return DbSet.Include(user => user.Role).FirstOrDefaultAsync(user => user.Id == id);
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

        public async Task<UserEntity> GetWithCarLockAsync(Guid userId)
        {
            return await DbSet.Include(user => user.CarLockEntity).FirstOrDefaultAsync(user => user.Id == userId);
        }

        public async Task<PageResult<UserEntity>> GetPageListAsync(UserFiltrationModel userFiltrationModel, int pageIndex, int pageSize)
        {
            var queryable = DbSet.AsQueryable().Where(GetFilterRule(userFiltrationModel));

            var totalItemsCount = await queryable.CountAsync();
            var items = await queryable.ToListAsync();

            return new PageResult<UserEntity>(items, totalItemsCount);
        }

        private Expression<Func<UserEntity, bool>> GetFilterRule(UserFiltrationModel filterModel)
        {
            return user =>
                (filterModel.Name != null && user.Name.Contains(filterModel.Name) ||
                 filterModel.Name == null) &&
                (filterModel.Surname != null && user.Surname.Contains(filterModel.Surname) ||
                 filterModel.Surname == null) &&
                (filterModel.Email != null && user.Email.Contains(filterModel.Email) ||
                 filterModel.Email == null);
        }
    }
}