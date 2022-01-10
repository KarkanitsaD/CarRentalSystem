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
        Task<(List<CarModel>, int)> GetPageListAsync(CarQueryModel queryModel, Guid? userId);
        Task CreateAsync(CarModel addCarModel);
        Task UpdateAsync(Guid id, CarModel updateCarModel);
        Task DeleteAsync(Guid id);
        Task LockCarAsync(Guid id);
        Task LockCarAsync(Guid carId, Guid userId);
    }
}