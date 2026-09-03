using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CarPictureRepository : BaseRepository<CarPictureEntity>, ICarPictureRepository
    {
        public CarPictureRepository(CarRentalSystemContext carRentalSystemContext) : base(carRentalSystemContext)
        {
        }

        public async Task<CarPictureEntity> GetByCarIdAsync(Guid carId)
        {
            var picture = await DbSet.FirstOrDefaultAsync(p => p.CarId == carId);
            return picture;
        }
    }
}