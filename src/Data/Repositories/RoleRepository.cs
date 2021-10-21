using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}