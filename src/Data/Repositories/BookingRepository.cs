using System;
using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

namespace Data.Repositories
{
    public class BookingRepository : BaseRepository<BookingEntity, Guid>, IBookingRepository
    {
        public BookingRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}