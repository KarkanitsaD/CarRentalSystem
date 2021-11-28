using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IBookingService
    {
        Task CreateAsync(string authorization, BookingModel bookingModel);
        Task DeleteAsync(string authorization, Guid bookingId);
    }
}