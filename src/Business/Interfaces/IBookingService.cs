using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IBookingService
    {
        BookingModel Get(Guid id);
        IEnumerable<BookingModel> GetList();
        Task CreateAsync(BookingModel bookingModel);
        Task UpdateAsync(BookingModel bookingModel);
        Task DeleteAsync(Guid id);
    }
}