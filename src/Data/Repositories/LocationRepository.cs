using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class LocationRepository : Repository<LocationEntity, int>, ILocationRepository
    {
        public LocationRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}