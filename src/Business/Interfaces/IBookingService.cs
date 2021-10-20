using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Models;

namespace Business.Interfaces
{
    public interface IBookingService
    {
        Task<int> Count(BookingFilterModel bookingFilterModel);
        Task<BookingModel> GetAsync(Guid id);
        Task<IList<BookingModel>> GetListAsync(BookingFilterModel bookingFilterModel);
        Task<IList<BookingModel>> GetPageListAsync(BookingFilterModel bookingFilterModel);
        Task CreateAsync(BookingModel bookingModel);
        Task UpdateAsync(BookingModel bookingModel);
        Task DeleteAsync(Guid id);
    }
}
