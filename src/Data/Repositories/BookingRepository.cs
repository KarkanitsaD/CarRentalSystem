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
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(CarRentalSystemContext context)
            : base(context)
        {
        }

        public async Task<PageResult<BookingEntity>> GetPageListAsync(Guid userId, BookingFiltrationModel bookingFiltrationModel, int pageIndex, int pageSize)
        {
            var queryable = DbSet.AsQueryable().Where(GetFilterExpression(userId, bookingFiltrationModel));
            var totalItemsCount = await queryable.CountAsync();

            var items = await queryable.Skip(pageSize * pageIndex).Take(pageSize)
                .Include(b => b.RentalPoint)
                    .ThenInclude(rp => rp.Country)
                .Include(b => b.RentalPoint)
                    .ThenInclude(rp => rp.City)
                .Include(b => b.AdditionalFacilityBookings)
                    .ThenInclude(ab => ab.AdditionalFacility)
                .ToListAsync();

            return new PageResult<BookingEntity>(items, totalItemsCount);
        }

        private Expression<Func<BookingEntity, bool>> GetFilterExpression(Guid userId, BookingFiltrationModel filtrationModel)
        {
            return booking =>
                userId == booking.UserId &&
                (filtrationModel.CountryId != null && booking.RentalPoint.CountryId == filtrationModel.CountryId ||
                 filtrationModel.CountryId == null) &&
                (filtrationModel.CityId != null && booking.RentalPoint.CityId == filtrationModel.CityId ||
                 filtrationModel.CityId == null) &&
                (filtrationModel.GetCurrent == null ||
                 filtrationModel.GetCurrent == false && booking.KeyHandOverTime <
                 DateTime.UtcNow.AddSeconds(booking.RentalPoint.City.TimeOffset) ||
                 filtrationModel.GetCurrent == true && booking.KeyHandOverTime >
                 DateTime.UtcNow.AddSeconds(booking.RentalPoint.City.TimeOffset));
        }
    }
}