using Data.Interfaces;
using Data.Models;

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
