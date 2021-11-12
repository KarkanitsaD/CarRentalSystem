using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class CountryRepository : BaseRepository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }
    }
}