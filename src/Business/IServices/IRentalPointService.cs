using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Query.RentalPoint;

namespace Business.IServices
{
    public interface IRentalPointService
    {
        Task<RentalPointModel> GetAsync(Guid id);
        Task<(List<RentalPointModel>, int)> GetPageListAsync(RentalPointQueryModel queryModel);
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(Guid id, RentalPointModel rentalPointModel);
        Task DeleteAsync(Guid id);
    }
}