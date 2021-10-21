using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IRentalPointService
    {
        RentalPointModel Get(Guid id);
        IEnumerable<RentalPointModel> GetList();
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(RentalPointModel rentalPointModel);
        Task DeleteAsync(Guid id);
    }
}