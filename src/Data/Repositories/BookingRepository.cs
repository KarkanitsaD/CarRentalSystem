﻿using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BookingRepository : BaseRepository<BookingEntity>, IBookingRepository
    {
        public BookingRepository(CarRentalSystemContext context)
            : base(context)
        {
        }

        public override async Task<PageResult<BookingEntity>> GetPageListAsync(QueryParameters<BookingEntity> queryParameters)
        {
            var query = DbSet.AsQueryable();

            query = BaseQuery(query, queryParameters);

            int totalItemsCount = await query.CountAsync();

            if (queryParameters.PaginationRule != null)
            {
                query = PaginationQuery(query, queryParameters.PaginationRule);
            }

            query = query.Include(b => b.Car)
                .Include(b => b.RentalPoint).ThenInclude(rp => rp.Country)
                .Include(b => b.RentalPoint).ThenInclude(rp => rp.City);

            var items = await query.ToListAsync();

            return new PageResult<BookingEntity>(items, totalItemsCount);
        }
    }
}