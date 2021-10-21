using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

namespace Data.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity, int>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}