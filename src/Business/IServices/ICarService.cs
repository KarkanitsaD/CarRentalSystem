using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.Car;

namespace Business.IServices
{
    public interface ICarService
    {
        Task<CarModel> GetAsync(Guid id);
        IEnumerable<CarModel> GetList();
        Task CreateAsync(AddCarModel addCarModel);
        Task UpdateAsync(Guid id, UpdateCarModel updateCarModel);
        Task DeleteAsync(Guid id);
    }
}