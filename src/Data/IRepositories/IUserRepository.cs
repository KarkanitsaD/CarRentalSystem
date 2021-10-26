using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetBy(string email);
        Task<UserEntity> GetBy(string email, string password);
    }
}