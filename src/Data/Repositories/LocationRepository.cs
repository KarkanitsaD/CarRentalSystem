using Data.Interfaces;
using Data.Models;

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
