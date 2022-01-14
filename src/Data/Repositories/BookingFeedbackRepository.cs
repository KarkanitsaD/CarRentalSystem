using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<BookingFeedbackEntity> GetByBookingIdAsync(Guid bookingId)
        {
            return await DbSet.FirstOrDefaultAsync(bf => bf.BookingId == bookingId);
        }

        public async Task<List<BookingFeedbackEntity>> GetAllByCarIdAsync(Guid carId)
        {
            return await DbSet.Where(bf => bf.CarId == carId).ToListAsync();
        }
    }
}