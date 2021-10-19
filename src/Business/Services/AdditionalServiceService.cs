using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class AdditionalServiceService : IAdditionalServiceService
    {
        public Task<IList<AdditionalServiceModel>> GetListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(AdditionalServiceModel businessModel)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(AdditionalServiceModel businessModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
