using Data.Entities;
using Data.IRepositories;

namespace Data.Repositories
{
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}