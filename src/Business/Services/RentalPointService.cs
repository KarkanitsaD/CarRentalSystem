using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class RentalPointService : IRentalPointService
    {
        public Task<RentalPointModel> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<RentalPointModel>> GetListAsync(RentalPointFilterModel rentalPointFilterModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<RentalPointModel>> GetPageListAsync(RentalPointFilterModel rentalPointFilterModel)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateAsync(RentalPointModel rentalPointModel)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RentalPointModel rentalPointModel)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetAllCountries()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetAllCities()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetTitles()
        {
            throw new System.NotImplementedException();
        }
    }
}
