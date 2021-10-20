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

        public async Task<BookingModel> GetAsync(Guid id)
        {
            var entity = await _bookingRepository.GetAsync(id);

            return _mapper.Map<BookingEntity, BookingModel>(entity);
        }

        public async Task<IList<BookingModel>> GetListAsync()
        {
            var entities = await _bookingRepository.GetListAsync();

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
    }
}
