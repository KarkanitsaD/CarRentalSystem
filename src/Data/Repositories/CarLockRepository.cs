using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class CarLockRepository : BaseRepository<CarLockEntity>, ICarLockRepository
    {
        public CarLockRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }
    }
}