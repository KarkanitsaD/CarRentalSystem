using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICarService
    {
        Task<int> Count(CarFilterModel carFilterModel);
        Task<CarModel> GetAsync(int id);
        Task<IList<CarModel>> GetListAsync(CarFilterModel carFilterModel);
        Task<IList<CarModel>> GetPageListAsync(CarFilterModel carFilterModel);
        Task CreateAsync(CarModel carModel);
        Task UpdateAsync(CarModel carModel);
        Task DeleteAsync(int id);
    }
}
