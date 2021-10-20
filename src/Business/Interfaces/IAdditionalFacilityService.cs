using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IAdditionalFacilityService
    {
        Task<IList<AdditionalFacilityModel>> GetListAsync();
        Task CreateAsync(AdditionalFacilityModel additionalFacilityModel);
        Task UpdateAsync(AdditionalFacilityModel additionalFacilityModel);
        Task DeleteAsync(int id);
    }
}