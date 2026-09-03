using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IAdditionalFacilityRepository : IBaseRepository<AdditionalFacilityEntity>
    {
        Task<List<AdditionalFacilityEntity>> GetAllByRentalPointIdAsync(Guid rentalPointId);
    }
}