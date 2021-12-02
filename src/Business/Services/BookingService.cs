using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Business.Query.Booking;
using Data.Entities;
using Data.IRepositories;
using Data.Query;

namespace Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository, ITokenService tokenService)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _tokenService = tokenService;
        }

        public async Task CreateAsync(string authorization, BookingModel bookingModel)
        {
            var filetRule = GetBookingExistsFilterRule(bookingModel.CarId, bookingModel.KeyReceivingTime,
                bookingModel.KeyHandOverTime);

            if (await _bookingRepository.ExistsAsync(filetRule))
            {
                throw new BadRequestException("The booking for the given time already exists");
            }

            var userId = _tokenService.GetClaimFromJwt(authorization.Split(' ')[1], ClaimTypes.NameIdentifier).Value;
            bookingModel.UserId = Guid.Parse(userId);
            var entity = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

            await _bookingRepository.CreateAsync(entity);
        }

        public async Task<(List<BookingModel>, int)> GetAllAsync(string authorization, BookingQueryModel queryModel)
        {
            var jwt = authorization.Split(' ')[1];
            var idClaim = _tokenService.GetClaimFromJwt(jwt, ClaimTypes.NameIdentifier);
            var userId = Guid.Parse(idClaim.Value);
            var queryParameters = new QueryParameters<BookingEntity>
            {
                FilterRule = GetBookingFilterRule(queryModel, userId),
                PaginationRule = GetPaginationRule(queryModel)
            };
            var result = await _bookingRepository.GetPageListAsync(queryParameters);

            var bookings = _mapper.Map<List<BookingEntity>, List<BookingModel>>(result.Items);
            return (bookings, result.TotalItemsCount);
        }

        public async Task DeleteAsync(string authorization, Guid id)
        {
            var entityToDelete = await _bookingRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            var jwt = authorization.Split(' ')[1];
            var roleClaim = _tokenService.GetClaimFromJwt(jwt, ClaimTypes.Role);

            if (roleClaim.Value == Policy.ForUserOnly)
            {
                var userId = _tokenService.GetClaimFromJwt(jwt, ClaimTypes.NameIdentifier).Value;
                if (entityToDelete.UserId != Guid.Parse(userId))
                {
                    throw new NotAuthenticatedException($"No permission to delete booking with id = {id}.");
                }
            }

            await _bookingRepository.DeleteAsync(entityToDelete);
        }

        protected virtual FilterRule<BookingEntity> GetBookingExistsFilterRule(Guid carId,
            DateTimeOffset keyReceivingTime,
            DateTimeOffset keyHandOverTime) => new FilterRule<BookingEntity>
        {
            FilterExpression = booking =>
                booking.CarId == carId &&
                !(booking.KeyReceivingTime > keyReceivingTime && booking.KeyReceivingTime > keyHandOverTime ||
                  booking.KeyHandOverTime < keyReceivingTime && booking.KeyHandOverTime < keyHandOverTime)
        };

        protected virtual FilterRule<BookingEntity> GetBookingFilterRule(BookingQueryModel queryModel, Guid userId) =>
            new FilterRule<BookingEntity>
            {
                FilterExpression = booking =>
                    booking.UserId == userId
            };

        protected virtual PaginationRule GetPaginationRule(BookingQueryModel queryModel) => new PaginationRule
        {
            Index = queryModel.PageIndex,
            Size = queryModel.PageSize
        };
    }
}