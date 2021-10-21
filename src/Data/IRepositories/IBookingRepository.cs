using System;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IBookingRepository : IRepository<BookingEntity, Guid>
    {

    }
}