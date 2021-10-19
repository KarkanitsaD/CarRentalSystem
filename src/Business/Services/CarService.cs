using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class CarService : ICarService
    {
        public Task<int> Count(CarFilterModel carFilterModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<CarModel> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CarModel>> GetListAsync(CarFilterModel carFilterModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<CarModel>> GetPageListAsync(CarFilterModel carFilterModel)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(CarModel carModel)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CarModel carModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
