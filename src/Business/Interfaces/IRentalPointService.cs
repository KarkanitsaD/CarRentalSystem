using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IRentalPointService
    {
        Task<RentalPointModel> GetAsync(int id);
        Task<IList<RentalPointModel>> GetListAsync();
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(RentalPointModel rentalPointModel);
        Task DeleteAsync(int id);
    }
}
