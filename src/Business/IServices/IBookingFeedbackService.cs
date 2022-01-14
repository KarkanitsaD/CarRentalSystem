using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IBookingFeedbackService
    {
        Task<BookingFeedbackModel> GetAsync(Guid bookingId);
        Task<List<BookingFeedbackModel>> GetAllByCarIdAsync(Guid carId);
        Task CreateAsync(BookingFeedbackModel bookingFeedbackModel);
        Task DeleteAsync(Guid bookingFeedbackId);
    }
}