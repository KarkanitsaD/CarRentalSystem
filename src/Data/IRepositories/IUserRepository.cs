using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByCredentialsAsync(string email, string password);
        Task<UserEntity> GetByEmailAsync(string email);
        Task<UserEntity> GetByRefreshTokenAsync(string refreshToken);
    }
}