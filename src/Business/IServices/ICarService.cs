using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface ICarService
    {
        Task<CarModel> GetAsync(Guid id);
        IEnumerable<CarModel> GetList();
        Task CreateAsync(CarModel carModel);
        Task UpdateAsync(Guid id, CarModel carModel);
        Task DeleteAsync(Guid id);
    }
}