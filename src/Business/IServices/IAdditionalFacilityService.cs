using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IAdditionalFacilityService
    {
        Task<List<AdditionalFacilityModel>> GetAllByRentalPointIdAsync(Guid rentalPointId);
        Task<AdditionalFacilityModel> CreateAsync(AdditionalFacilityModel createModel);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, AdditionalFacilityModel updateModel);
    }
}