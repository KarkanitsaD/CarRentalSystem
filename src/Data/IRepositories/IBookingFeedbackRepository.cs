using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IBookingFeedbackRepository: IBaseRepository<BookingFeedbackEntity>
    {
        Task<BookingFeedbackEntity> GetByBookingIdAsync(Guid bookingId);
        Task<List<BookingFeedbackEntity>> GetAllByCarIdAsync(Guid carId);
        Task<double> GetCarAverageFeedbackAsync(Guid carId);
    }
}