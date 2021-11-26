using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IRentalPointService
    {
        Task<RentalPointModel> GetAsync(Guid id);
        Task<List<RentalPointModel>> GetAllAsync();
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(Guid id, RentalPointModel rentalPointModel);
        Task DeleteAsync(Guid id);
    }
}