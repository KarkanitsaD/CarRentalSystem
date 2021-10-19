using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RentalPointRepository : Repository<RentalPointEntity, int>, IRentalPointRepository
    {
        public RentalPointRepository(ApplicationContext context)
            : base(context)
        {

        }

        public async Task<IList<string>> GetRentalPointsCountriesAsync()
        {
            var query = Set.AsQueryable();

            return await query.Select(rp => rp.Location.Country).ToListAsync();
        }

        public async Task<IList<string>> GetRentalPointsCitiesAsync()
        {
            var query = Set.AsQueryable();

            return await query.Select(rp => rp.Location.City).ToListAsync();
        }

        public async Task<IList<string>> GetRentalPointTitlesAsync()
        {
            var query = Set.AsQueryable();

            return await query.Select(rp => rp.Title).ToListAsync();
        }
    }
}
