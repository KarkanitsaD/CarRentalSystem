using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookingFeedbackRepository: BaseRepository<BookingFeedbackEntity>, IBookingFeedbackRepository
    {

        public BookingFeedbackRepository(CarRentalSystemContext carRentalSystemContext)
            : base(carRentalSystemContext)
        {
        }

        public async Task<BookingFeedbackEntity> GetByBookingId(Guid bookingId)
        {
            return await DbSet.FirstOrDefaultAsync(bf => bf.BookingId == bookingId);
        }
    }
}