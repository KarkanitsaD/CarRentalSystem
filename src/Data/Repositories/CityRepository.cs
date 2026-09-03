
using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CityRepository : BaseRepository<CityEntity>, ICityRepository
    {
        public CityRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
            
        }

        public async Task<CityEntity> GetByTitleAndCountryIdAsync(string title, Guid countryId)
        {
            return await DbSet.FirstOrDefaultAsync(city => city.Title == title && city.CountryId == countryId);
        }
    }
}