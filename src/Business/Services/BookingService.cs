using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Query;

namespace Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMapper mapper, ApplicationContext context, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _context = context;
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Count(BookingFilterModel bookingFilterModel)
        {
            var filterRule = DefineFilterRule(bookingFilterModel);
            return await _bookingRepository.Count(filterRule);
        }

        public async Task<BookingModel> GetAsync(Guid id)
        {
            var filterRule = new FilterRule<BookingEntity, Guid>
            {
                FilterExpression = booking =>
                    booking.Id == id
            };

            var entity = await _bookingRepository.GetAsync(filterRule);

            return _mapper.Map<BookingEntity, BookingModel>(entity);
        }

        public async Task<IList<BookingModel>> GetListAsync(BookingFilterModel bookingFilterModel)
        {
            var queryParameters = new QueryParameters<BookingEntity, Guid>
            {
                FilterRule = DefineFilterRule(bookingFilterModel),
                SortRule = DefineSortRule(bookingFilterModel)
            };

            var entities = await _bookingRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<BookingEntity>, IList<BookingModel>>(entities);
        }

        public async Task<IList<BookingModel>> GetPageListAsync(BookingFilterModel bookingFilterModel)
        {
            var queryParameters = new QueryParameters<BookingEntity, Guid>
            {
                FilterRule = DefineFilterRule(bookingFilterModel),
                SortRule = DefineSortRule(bookingFilterModel),
                PaginationRule = new PaginationRule
                {
                    Index = bookingFilterModel.PageIndex,
                    Size = bookingFilterModel.PageSize
                }
            };

            var entities = await _bookingRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<BookingEntity>, IList<BookingModel>>(entities);
        }

        public async Task CreateAsync(BookingModel bookingModel)
        {
            var entity = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

            await _bookingRepository.CreateAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookingModel bookingModel)
        {
            var entity = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

            _bookingRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _bookingRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }

        private FilterRule<BookingEntity, Guid> DefineFilterRule(BookingFilterModel bookingFilterModel)
        {
            throw new NotImplementedException();
            //TODO: write logic to filter bookings
        }

        private SortRule<BookingEntity, Guid> DefineSortRule(BookingFilterModel bookingFilterModel)
        {
            var sortRule = new SortRule<BookingEntity, Guid>();

            if (bookingFilterModel.InAscendingOrder != null)
            {
                sortRule.InAscendingOrder = (bool)bookingFilterModel.InAscendingOrder;
                sortRule.SortExpression = car => car.Id;
            }

            return sortRule;
        }
    }
}
