using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.IRepositories;

namespace Business.Services
{
    public class BookingFeedbackService : IBookingFeedbackService
    {
        private readonly IBookingFeedbackRepository _bookingFeedbackRepository;
        private readonly IMapper _mapper;

        public BookingFeedbackService(IBookingFeedbackRepository bookingFeedbackRepository, IMapper mapper)
        {
            _bookingFeedbackRepository = bookingFeedbackRepository;
            _mapper = mapper;
        }

        public async Task<BookingFeedbackModel> GetAsync(Guid bookingId)
        {
            var entity =  await _bookingFeedbackRepository.GetByBookingIdAsync(bookingId);
            var model = _mapper.Map<BookingFeedbackEntity, BookingFeedbackModel>(entity);
            return model;
        }

        public async Task CreateAsync(BookingFeedbackModel bookingFeedbackModel)
        {
            var entity = _mapper.Map<BookingFeedbackModel, BookingFeedbackEntity>(bookingFeedbackModel);
            await _bookingFeedbackRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Guid bookingFeedbackId)
        {
            var entityToDelete = await _bookingFeedbackRepository.GetAsync(bookingFeedbackId);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {bookingFeedbackId} not found.");
            }

            await _bookingFeedbackRepository.DeleteAsync(entityToDelete);
        }
    }
}