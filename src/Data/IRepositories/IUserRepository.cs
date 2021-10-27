using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByAsync(string email, string password);
    }
}