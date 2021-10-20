using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class AdditionalServiceRepository : Repository<AdditionalServiceEntity, int>, IAdditionalServiceRepository
    {
        public AdditionalServiceRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
