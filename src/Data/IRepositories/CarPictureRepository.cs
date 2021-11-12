using Data.Entities;
using Data.Repositories;

namespace Data.IRepositories
{
    public class CarPictureRepository : BaseRepository<CarPictureEntity>, ICarPictureRepository
    {
        public CarPictureRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }
    }
}