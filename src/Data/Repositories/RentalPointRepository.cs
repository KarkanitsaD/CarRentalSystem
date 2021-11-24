using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RentalPointRepository : BaseRepository<RentalPointEntity>, IRentalPointRepository
    {
        public RentalPointRepository(CarRentalSystemContext context)
            : base(context)
        {

        }

        public override async Task<List<RentalPointEntity>> GetListAsync(QueryParameters<RentalPointEntity> queryParameters = null)
        {
            var query = DbSet.AsQueryable();

            if (queryParameters == null)
            {
                return await query.Include(rp => rp.City).Include(rp => rp.Country).ToListAsync();
            }

            query = BaseQuery(query, queryParameters);

            query.Include(rp => rp.City).Include(rp => rp.Country);

            return await query.ToListAsync();
        }
    }
}