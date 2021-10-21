using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICarService
    {
        CarModel Get(Guid id);
        IEnumerable<CarModel> GetList();
        Task CreateAsync(CarModel carModel);
        Task UpdateAsync(CarModel carModel);
        Task DeleteAsync(Guid id);
    }
}