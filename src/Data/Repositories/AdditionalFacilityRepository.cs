using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AdditionalFacilityRepository : BaseRepository<AdditionalFacilityEntity>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(CarRentalSystemContext carRentalSystemContext)
            : base(carRentalSystemContext)
        {
        }

        public async Task<List<AdditionalFacilityEntity>> GetAllByRentalPointIdAsync(Guid rentalPointId)
        {
            return await DbSet.Where(f => f.RentalPointId == rentalPointId).ToListAsync();
        }
    }
}