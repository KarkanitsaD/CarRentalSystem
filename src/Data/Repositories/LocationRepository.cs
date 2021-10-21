using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class LocationRepository : BaseRepository<LocationEntity>, ILocationRepository
    {
        public LocationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}