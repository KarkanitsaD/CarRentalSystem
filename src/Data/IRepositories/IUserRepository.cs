using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetByEmailAndPassword(string email, string password);
    }
}