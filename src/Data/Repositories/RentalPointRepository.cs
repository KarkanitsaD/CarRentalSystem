using System;
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

        public override async Task<PageResult<RentalPointEntity>> GetPageListAsync(QueryParameters<RentalPointEntity> queryParameters)
        {
            var query = DbSet.AsQueryable();

            query = query.Include(rp => rp.City).Include(rp => rp.Country);

            query = BaseQuery(query, queryParameters);

            int totalItemsCount = await query.CountAsync();

            if (queryParameters.PaginationRule is {IsValid: true})
            {
                query = PaginationQuery(query, queryParameters.PaginationRule);
            }

            var items = await query.ToListAsync();

            return new PageResult<RentalPointEntity>(items, totalItemsCount);
        }

        public override async Task<RentalPointEntity> GetAsync(Guid id)
        {
            return await DbSet.Include(rp => rp.City).Include(rp => rp.Country).FirstOrDefaultAsync(rp => rp.Id == id);
        }
    }
}