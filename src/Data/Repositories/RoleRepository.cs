using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(CarRentalSystemContext context)
            : base(context)
        {
        }

        public override async Task<List<RoleEntity>> GetListAsync(QueryParameters<RoleEntity> queryParameters = null)
        {
            var query = DbSet.AsQueryable();

            if (queryParameters == null)
            {
                return await query.Include(r => r.Users).ToListAsync();
            }

            query = BaseQuery(query, queryParameters);

            query.Include(r => r.Users);

            return await query.ToListAsync();
        }
    }
}