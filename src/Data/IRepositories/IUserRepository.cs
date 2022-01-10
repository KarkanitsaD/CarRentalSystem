using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.Query;
using Data.Query.FiltrationModels;

namespace Data.IRepositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByCredentialsAsync(string email, string password);
        Task<UserEntity> GetByEmailAsync(string email);
        Task<UserEntity> GetByRefreshTokenAsync(string refreshToken);
        Task<UserEntity> GetWithCarLockAsync(Guid userId);
        Task<PageResult<UserEntity>> GetPageListAsync(UserFiltrationModel userFiltrationModel, int pageIndex, int pageSize);
    }
}