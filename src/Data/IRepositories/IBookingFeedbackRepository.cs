using System;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IBookingFeedbackRepository: IBaseRepository<BookingFeedbackEntity>
    {
        Task<BookingFeedbackEntity> GetByBookingId(Guid bookingId);
    }
}