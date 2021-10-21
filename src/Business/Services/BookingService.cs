using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.IRepositories;

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

            if (entity == null)
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");

            return _mapper.Map<BookingEntity, BookingModel>(entity);
        }

        public IEnumerable<BookingModel> GetList()
        {
            var entities = _bookingRepository.GetList();

            return _mapper.Map<IEnumerable<BookingEntity>, IEnumerable<BookingModel>>(entities);
        }

        public async Task CreateAsync(BookingModel bookingModel)
        {
            var entity = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

            await _bookingRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid id, BookingModel bookingModel)
        {
            if (id != bookingModel.Id)
                throw new BadRequestException("Check data.");

            var entityToUpdate = await _bookingRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(bookingModel)} with id = {id} not found.");

            entityToUpdate = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

            await _bookingRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _bookingRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _bookingRepository.DeleteAsync(entityToDelete);
        }
    }
}