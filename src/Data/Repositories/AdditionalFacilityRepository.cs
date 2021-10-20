using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class AdditionalFacilityRepository : Repository<AdditionalFacilityEntity, int>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
