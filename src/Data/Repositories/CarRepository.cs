using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CarRepository : BaseRepository<CarEntity>, ICarRepository
    {
        public CarRepository(CarRentalSystemContext context)
            : base(context)
        {
        }

        public override async Task<CarEntity> GetAsync(Guid id)
        {
            return await DbSet.Include(c => c.CarLockEntity).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CarEntity> GetWithCarLockAsync(Guid carId)
        {
            return await DbSet.Include(car => car.CarLockEntity).FirstOrDefaultAsync(car => car.Id == carId);
        }
    }
}