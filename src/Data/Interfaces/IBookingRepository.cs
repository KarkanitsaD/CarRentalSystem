using System;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IBookingRepository : IRepository<BookingEntity, Guid>
    {

    }
}
