using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Data.Query.FiltrationModels;
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

        public async Task<PageResult<CarEntity>> GetPageListAsync(Guid? userId, CarFiltrationModel carFiltrationModel, int pageIndex, int pageSize)
        {
            var queryable = DbSet.AsQueryable().Where(GetFilterExpression(userId, carFiltrationModel));
            var totalItemsCount = await queryable.CountAsync();

            var items = await queryable.Skip(pageSize * pageIndex).Take(pageSize).ToListAsync();

            return new PageResult<CarEntity>(items, totalItemsCount);
        }

        private Expression<Func<CarEntity, bool>> GetFilterExpression(Guid? userId, CarFiltrationModel filtrationModel)
        {
            return car =>
                (car.CarLockEntity != null && (car.CarLockEntity.LockTime.AddMinutes(5) < DateTime.Now ||
                                               car.CarLockEntity.UserId == userId) || car.CarLockEntity == null) &&
                (filtrationModel.KeyReceivingTime != null && filtrationModel.KeyHandOverTime != null && car.Bookings
                     .AsQueryable()
                     .Count(booking =>
                         !(booking.KeyReceivingTime > filtrationModel.KeyReceivingTime &&
                           booking.KeyReceivingTime > filtrationModel.KeyHandOverTime ||
                           booking.KeyHandOverTime < filtrationModel.KeyReceivingTime &&
                           booking.KeyHandOverTime < filtrationModel.KeyHandOverTime)) == 0 ||
                 filtrationModel.KeyReceivingTime == null || filtrationModel.KeyHandOverTime == null) &&
                (filtrationModel.Brand != null && car.Brand.Contains(filtrationModel.Brand) ||
                 filtrationModel.Brand == null) &&
                (filtrationModel.Color != null && car.Color == filtrationModel.Color ||
                 filtrationModel.Color == null) &&
                (filtrationModel.MaxPricePerDay != null && car.PricePerDay < filtrationModel.MaxPricePerDay ||
                 filtrationModel.MaxPricePerDay == null) &&
                (filtrationModel.MinPricePerDay != null && car.PricePerDay > filtrationModel.MinPricePerDay ||
                 filtrationModel.MinPricePerDay == null) &&
                (filtrationModel.RentalPointId != null && car.RentalPointId == filtrationModel.RentalPointId ||
                 filtrationModel.RentalPointId == null);
        }
    }
}