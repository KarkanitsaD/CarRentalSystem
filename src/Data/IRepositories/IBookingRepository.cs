using System;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IBookingRepository : IBaseRepository<BookingEntity, Guid>
    {

    }
}