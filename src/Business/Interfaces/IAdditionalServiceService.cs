using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IAdditionalServiceService
    {
        Task<IList<AdditionalServiceModel>> GetListAsync();
        Task CreateAsync(AdditionalServiceModel businessModel);
        Task UpdateAsync(AdditionalServiceModel businessModel);
        Task DeleteAsync(int id);
    }
}
