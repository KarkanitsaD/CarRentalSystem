using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Models;

namespace Business.Interfaces
{
    public interface IRentalPointService
    {
        Task<RentalPointModel> GetAsync(int id);
        Task<IList<RentalPointModel>> GetListAsync(RentalPointFilterModel rentalPointFilterModel);
        Task<IList<RentalPointModel>> GetPageListAsync(RentalPointFilterModel rentalPointFilterModel);
        Task CreateAsync(RentalPointModel rentalPointModel);
        Task UpdateAsync(RentalPointModel rentalPointModel);
        Task DeleteAsync(int id);
        Task<IList<string>> GetAllCountries();
        Task<IList<string>> GetAllCities();
        Task<IList<string>> GetTitles();
    }
}
