using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}