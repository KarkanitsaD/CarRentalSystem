using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IRentalPointService
    {
        RentalPointModel Get(int id);
        IEnumerable<RentalPointModel> GetList();
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(RentalPointModel rentalPointModel);
        Task DeleteAsync(int id);
    }
}