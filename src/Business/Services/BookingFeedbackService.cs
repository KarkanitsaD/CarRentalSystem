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
            if (entity == null)
            {
                throw new NotFoundException($"There are not bookingFeedback with booking id = {bookingId}");
            }
            var model = _mapper.Map<BookingFeedbackEntity, BookingFeedbackModel>(entity);
            return model;
        }

        public async Task<List<BookingFeedbackModel>> GetAllByCarIdAsync(Guid carId)
        {
            var entities = await _bookingFeedbackRepository.GetAllByCarIdAsync(carId);
            var models = _mapper.Map<List<BookingFeedbackEntity>, List<BookingFeedbackModel>>(entities);
            return models;
        }

        public async Task CreateAsync(BookingFeedbackModel bookingFeedbackModel)
        {
            var entity = _mapper.Map<BookingFeedbackModel, BookingFeedbackEntity>(bookingFeedbackModel);
            await _bookingFeedbackRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid feedbackId, BookingFeedbackModel updateModel, Guid? userId)
        {
            if (feedbackId != updateModel.Id)
            {
                throw new BadRequestException("Check identifiers!");
            }

            var entityToUpdate = await _bookingFeedbackRepository.GetAsync(feedbackId);

            if (entityToUpdate == null)
            {
                throw new NotFoundException("Booking feedback not found!");
            }

            if (userId != null && userId != entityToUpdate.UserId)
            {
                throw new NotAuthorizedException("No permissions for this action!");
            }

            entityToUpdate.Comment = updateModel.Comment;
            entityToUpdate.Rating = updateModel.Rating;

            await _bookingFeedbackRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid bookingFeedbackId, Guid? userId)
        {
            var entityToDelete = await _bookingFeedbackRepository.GetAsync(bookingFeedbackId);
            if (entityToDelete == null)
            {
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {bookingFeedbackId} not found.");
            }

            if (userId != null && userId != entityToDelete.UserId)
            {
                throw new NotAuthorizedException("No permissions for this action!");
            }

            await _bookingFeedbackRepository.DeleteAsync(entityToDelete);
        }
    }
}