using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IBookingFeedbackService
    {
        Task<BookingFeedbackModel> GetAsync(Guid bookingId);
        Task CreateAsync(BookingFeedbackModel bookingFeedbackModel);
        Task DeleteAsync(Guid bookingFeedbackId);
    }
}