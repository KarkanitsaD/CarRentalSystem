using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

namespace Data.Repositories
{
    public class LocationRepository : BaseRepository<LocationEntity, int>, ILocationRepository
    {
        public LocationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}