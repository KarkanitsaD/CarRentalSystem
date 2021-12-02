using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Policies;
using Business.Query.Booking;
using Data;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IBookingRepository _bookingRepository;
        private readonly CarRentalSystemContext _context;

        public BookingService(IMapper mapper, IBookingRepository bookingRepository, ITokenService tokenService, CarRentalSystemContext context)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task CreateAsync(string authorization, BookingModel bookingModel)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var filetRule = GetBookingExistsFilterRule(bookingModel.CarId, bookingModel.KeyReceivingTime,
                    bookingModel.KeyHandOverTime);

                if (await _context.Bookings.CountAsync(filetRule.FilterExpression) > 0)
                {
                    throw new BadRequestException("The booking for the given time already exists");
                }

                var userId = _tokenService.GetClaimFromJwt(authorization.Split(' ')[1], ClaimTypes.NameIdentifier)
                    .Value;
                bookingModel.UserId = Guid.Parse(userId);
                var entity = _mapper.Map<BookingModel, BookingEntity>(bookingModel);

                await _context.Bookings.AddAsync(entity);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (BadRequestException)
            {
                await transaction.RollbackAsync();
                throw;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }
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
                    (userId != null && userId == booking.UserId || userId == null) &&
                    (queryModel.CountryId != null && booking.RentalPoint.CountryId == queryModel.CountryId || queryModel.CountryId == null) && 
                    (queryModel.CityId != null && booking.RentalPoint.CityId == queryModel.CityId || queryModel.CityId == null) && 
                    (queryModel.GetCurrent == null ||
                     queryModel.GetCurrent == false && booking.KeyHandOverTime < DateTimeOffset.Now ||
                     queryModel.GetCurrent == true && booking.KeyHandOverTime > DateTimeOffset.Now)
            };

        protected virtual PaginationRule GetPaginationRule(BookingQueryModel queryModel) => new PaginationRule
        {
            Index = queryModel.PageIndex,
            Size = queryModel.PageSize
        };
    }
}