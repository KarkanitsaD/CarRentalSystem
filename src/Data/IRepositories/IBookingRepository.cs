using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.Query;
using Data.Query.FiltrationModels;

namespace Data.IRepositories
{
    public interface IBookingRepository : IBaseRepository<BookingEntity>
    {
        Task<PageResult<BookingEntity>> GetPageListAsync(Guid userId, BookingFiltrationModel bookingFiltrationModel, int pageIndex, int pageSize);
    }
}