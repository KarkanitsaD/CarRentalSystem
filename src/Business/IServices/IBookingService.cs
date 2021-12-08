using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Query.Booking;

namespace Business.IServices
{
    public interface IBookingService
    {
        Task CreateAsync(Guid userId, BookingModel bookingModel);
        Task<(List<BookingModel>, int)> GetAllAsync(string authorization, BookingQueryModel queryModel);
        Task DeleteAsync(string authorization, Guid bookingId);
    }
}