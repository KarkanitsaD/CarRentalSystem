using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class RentalPointRepository : BaseRepository<RentalPointEntity>, IRentalPointRepository
    {
        public RentalPointRepository(CarRentalSystemContext context)
            : base(context)
        {
        }
    }
}