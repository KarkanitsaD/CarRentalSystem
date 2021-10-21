using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

namespace Data.Repositories
{
    public class RoleRepository : Repository<RoleEntity, int>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}