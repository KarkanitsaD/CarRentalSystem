using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class AdditionalFacilityRepository : BaseRepository<AdditionalFacilityEntity>, IAdditionalFacilityRepository
    {
        public AdditionalFacilityRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}