using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Query.Car;
using Data;
using Data.Entities;
using Data.IRepositories;
using Data.Query.FiltrationModels;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IRentalPointRepository _rentalPointRepository;
        private readonly ICarPictureRepository _carPictureRepository;
        private readonly CarRentalSystemContext _context;

        public CarService(
            IMapper mapper,
            ICarRepository carRepository,
            IRentalPointRepository rentalPointRepository,
            ICarPictureRepository carPictureRepository,
            CarRentalSystemContext context)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _rentalPointRepository = rentalPointRepository;
            _carPictureRepository = carPictureRepository;
            _context = context;
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            var entity = await _carRepository.GetAsync(id);

            if (entity == null)
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");

            return _mapper.Map<CarEntity, CarModel>(entity);
        }

        public async Task<(List<CarModel>, int)> GetPageListAsync(CarQueryModel queryModel, Guid? userId)
        {
            if (!queryModel.IsValidPagination)
            {
                throw new BadRequestException("Pagination rule is not valid");
            }

            var filtrationModel = _mapper.Map<CarQueryModel, CarFiltrationModel>(queryModel);

            var paginationResult = await _carRepository.GetPageListAsync(userId, filtrationModel, queryModel.PageIndex, queryModel.PageSize);

            var carModels = _mapper.Map<List<CarEntity>, List<CarModel>>(paginationResult.Items);

            return (carModels, paginationResult.TotalItemsCount);
        }

        public async Task CreateAsync(CarModel addCarModel)
        {
            if (await _rentalPointRepository.GetAsync(addCarModel.RentalPointId) == null)
            {
                throw new BadRequestException("Invalid rental point Id");
            }

            var carEntity = _mapper.Map<CarModel, CarEntity>(addCarModel);

            await _carRepository.CreateAsync(carEntity);
        }

        public async Task UpdateAsync(Guid id, CarModel carModel)
        {
            if (id != carModel.Id)
                throw new BadRequestException("Check data.");

            var entityToUpdate = await _carRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(carModel)} with id = {id} not found.");

            var updatedEntity = _mapper.Map<CarModel, CarEntity>(carModel);

            entityToUpdate.RentalPointId = updatedEntity.RentalPointId;
            entityToUpdate.PricePerDay = updatedEntity.PricePerDay;
            entityToUpdate.Brand = updatedEntity.Brand;
            entityToUpdate.Model = updatedEntity.Model;
            entityToUpdate.Color = updatedEntity.Color;
            entityToUpdate.NumberOfSeats = updatedEntity.NumberOfSeats;
            entityToUpdate.TransmissionType = updatedEntity.TransmissionType;
            entityToUpdate.FuelConsumptionPerHundredKilometers = updatedEntity.FuelConsumptionPerHundredKilometers;
            entityToUpdate.Description = updatedEntity.Description;

            await _carPictureRepository.UpdateAsync(updatedEntity.Picture);

            await _carRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _carRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _carRepository.DeleteAsync(entityToDelete);
        }

        public async Task LockCarAsync(Guid id)
        {
            var car = await _carRepository.GetAsync(id);

            if (car == null)
                throw new NotFoundException($"Car with id = {id} not found.");

            car.LastViewTime = DateTime.Now;
            await _carRepository.UpdateAsync(car);
        }

        public async Task LockCarAsync(Guid carId, Guid userId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var carToLock = await _context.Cars.Include(c => c.CarLockEntity).FirstOrDefaultAsync(c => c.Id == carId);
                if (carToLock.CarLockEntity != null)
                {
                    if (carToLock.CarLockEntity.LockTime.AddMinutes(5) > DateTime.Now &&
                        carToLock.CarLockEntity.UserId != userId)
                    {
                        throw new BadRequestException("This car is already locked.");
                    }
                    _context.CarLocks.Remove(carToLock.CarLockEntity);
                    await _context.SaveChangesAsync();
                }

                var user = await _context.Users.Include(u => u.CarLockEntity).FirstOrDefaultAsync(u => u.Id == userId);
                if (user.CarLockEntity != null)
                {
                    user.CarLockEntity.CarId = carId;
                    user.CarLockEntity.LockTime = DateTime.Now;
                    _context.CarLocks.Update(user.CarLockEntity);
                }
                else
                {
                    var carLock = new CarLockEntity
                    {
                        UserId = userId,
                        CarId = carId,
                        LockTime = DateTime.Now
                    };
                    await _context.CarLocks.AddAsync(carLock);
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }
        }
    }
}