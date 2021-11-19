using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class CityRepository : BaseRepository<CityEntity>, ICityRepository
    {
        public CityRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }
    }
}