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
    public class RentalPointRepository : BaseRepository<RentalPointEntity>, IRentalPointRepository
    {
        public RentalPointRepository(CarRentalSystemContext context)
            : base(context)
        {

        }

        public override async Task<RentalPointEntity> GetAsync(Guid id)
        {
            return await DbSet.Include(rp => rp.City)
                .Include(rp => rp.Country)
                .FirstOrDefaultAsync(rp => rp.Id == id);
        }

        public async Task<PageResult<RentalPointEntity>> GetPageListAsync(RentalPointFiltrationModel rentalPointFiltrationModel, int pageIndex, int pageSize)
        {
            var queryable = DbSet.AsQueryable().Where(GetFilterExpression(rentalPointFiltrationModel));
            var totalItemsCount = await queryable.CountAsync();

            queryable = queryable.Include(rp => rp.City)
                .Include(rp => rp.Country);

            var items = await queryable.ToListAsync();

            return new PageResult<RentalPointEntity>(items, totalItemsCount);
        }

        private Expression<Func<RentalPointEntity, bool>> GetFilterExpression(
            RentalPointFiltrationModel filtrationModel)
        {
            return rentalPoint =>
                (filtrationModel.KeyReceivingTime != null && filtrationModel.KeyHandOverTime != null &&
                 rentalPoint.Cars.AsQueryable().Include(car => car.Bookings)
                     .Count(car => 
                         (car.CarLockEntity != null && car.CarLockEntity.LockTime.AddMinutes(5) < DateTime.Now || car.CarLockEntity == null) &&
                                   car.Bookings.AsQueryable()
                         .Count(booking =>
                             !(booking.KeyReceivingTime > filtrationModel.KeyReceivingTime &&
                               booking.KeyReceivingTime > filtrationModel.KeyHandOverTime ||
                               booking.KeyHandOverTime < filtrationModel.KeyReceivingTime &&
                               booking.KeyHandOverTime < filtrationModel.KeyHandOverTime)) == 0) >=
                 filtrationModel.NumberOfAvailableCars ||
                 filtrationModel.KeyReceivingTime == null || filtrationModel.KeyHandOverTime == null) &&
                (filtrationModel.CountryId != null && rentalPoint.CountryId == filtrationModel.CountryId ||
                 filtrationModel.CountryId == null) &&
                (filtrationModel.CityId != null && rentalPoint.CityId == filtrationModel.CityId ||
                 filtrationModel.CityId == null);
        }
    }
}