using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Models.RentalPoint;

namespace Business.IServices
{
    public interface IRentalPointService
    {
        Task<RentalPointModel> GetAsync(Guid id);
        IEnumerable<RentalPointModel> GetList();
        IEnumerable<RentalPointAddCarResponseModel> GetRentalPointAddCarModels();
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(Guid id, RentalPointModel rentalPointModel);
        Task DeleteAsync(Guid id);
    }
}