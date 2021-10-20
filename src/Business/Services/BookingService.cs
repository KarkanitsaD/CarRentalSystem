using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository)
        {
            _mapper = mapper;
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
        }

        public async Task UpdateAsync(BookingModel bookingModel)
        {
            var entity = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

            _bookingRepository.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _bookingRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");
        }
    }
}