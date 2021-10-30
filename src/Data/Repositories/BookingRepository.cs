using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(CarRentalSystemContext context)
            : base(context)
        {
        }
    }
}