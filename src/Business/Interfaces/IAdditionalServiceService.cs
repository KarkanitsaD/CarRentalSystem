using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IAdditionalServiceService
    {
        Task<IList<AdditionalServiceModel>> GetListAsync();
        Task CreateAsync(AdditionalServiceModel additionalServiceModel);
        Task UpdateAsync(AdditionalServiceModel additionalServiceModel);
        Task DeleteAsync(int id);
    }
}
