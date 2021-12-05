using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Query.Car;

namespace Business.IServices
{
    public interface ICarService
    {
        Task<CarModel> GetAsync(Guid id);
        Task<(List<CarModel>, int)> GetPageListAsync(CarQueryModel queryModel);
        Task CreateAsync(CarModel addCarModel);
        //Task CreateRangeAsync(List<CarModel> carModels);
        Task UpdateAsync(Guid id, CarModel updateCarModel);
        Task DeleteAsync(Guid id);
        Task LockCarAsync(Guid id);
    }
}