using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
using Data.Query.FiltrationModels;
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

        public async Task CreateAsync(Guid userId, BookingModel bookingModel)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var carFilter = GetCarFilterExpression((Guid) bookingModel.RentalPointId, bookingModel.CarId);

                if (await _context.RentalPoints.CountAsync(carFilter) == 0)
                {
                    throw new NotFoundException("Car not found.");
                }

                var carLock = await _context.CarLocks.FirstOrDefaultAsync(cl => cl.CarId == bookingModel.CarId);
                if (carLock != null)
                {
                    _context.CarLocks.Remove(carLock);
                }
                await _context.SaveChangesAsync();

                var rentalPoint = await _context.RentalPoints.Include(rp => rp.City)
                    .FirstOrDefaultAsync(rp => rp.Id == bookingModel.RentalPointId);

                if (bookingModel.KeyReceivingTime < DateTime.UtcNow.AddSeconds(rentalPoint.City.TimeOffset))
                {
                    throw new InvalidTimeRangeException(
                        "Invalid time range for this country. Entered time is over in this country!");
                }

                var bookingFilter = GetBookingExistsFilterExpression(bookingModel.CarId, bookingModel.KeyReceivingTime,
                    bookingModel.KeyHandOverTime);

                if (await _context.Bookings.CountAsync(bookingFilter) > 0)
                {
                    throw new BadRequestException("The booking for the given time already exists.");
                }

                bookingModel.UserId = userId;
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
            catch (InvalidTimeRangeException)
            {
                await transaction.CommitAsync();
                throw;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }
        }

        public async Task<(List<BookingModel>, int)> GetAllAsync(Guid userId, BookingQueryModel queryModel)
        {
            var bookingFiltration = _mapper.Map<BookingQueryModel, BookingFiltrationModel>(queryModel);
            var result = await _bookingRepository.GetPageListAsync(userId, bookingFiltration, queryModel.PageIndex, queryModel.PageSize);

            var bookings = _mapper.Map<List<BookingEntity>, List<BookingModel>>(result.Items);
            return (bookings, result.TotalItemsCount);
        }

        public async Task DeleteAsync(Guid userId, Guid id)
        {
            var entityToDelete = await _bookingRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            if (entityToDelete.UserId != userId)
            { 
                throw new NotAuthenticatedException($"No permission to delete booking with id = {id}.");
            }

            await _bookingRepository.DeleteAsync(entityToDelete);
        }

        protected virtual Expression<Func<BookingEntity, bool>> GetBookingExistsFilterExpression(Guid carId,
            DateTimeOffset keyReceivingTime,
            DateTimeOffset keyHandOverTime)
        {
            return booking =>
                booking.CarId == carId &&
                !(booking.KeyReceivingTime > keyReceivingTime && booking.KeyReceivingTime > keyHandOverTime ||
                  booking.KeyHandOverTime < keyReceivingTime && booking.KeyHandOverTime < keyHandOverTime);
        }

        protected virtual Expression<Func<RentalPointEntity, bool>> GetCarFilterExpression(Guid rentalPointId, Guid carId)
        {
            return rentalPoint =>
                rentalPoint.Id == rentalPointId &&
                rentalPoint.Cars.AsQueryable().Count(car => car.Id == carId) > 0;
        }
    }
}