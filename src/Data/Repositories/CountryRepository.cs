using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CountryRepository : BaseRepository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }

        public async Task<CountryEntity> GetByTitleAsync(string title)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Title == title);
        }
    }
}