using Data.Interfaces;
using Data.Models;

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
