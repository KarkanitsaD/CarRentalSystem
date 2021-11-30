using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Business.Query.Car;
using Data.Entities;
using Data.IRepositories;
using Data.Query;

namespace Business.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IRentalPointRepository _rentalPointRepository;
        private readonly ICarPictureRepository _carPictureRepository;

        public CarService(IMapper mapper, ICarRepository carRepository, IRentalPointRepository rentalPointRepository, ICarPictureRepository carPictureRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _rentalPointRepository = rentalPointRepository;
            _carPictureRepository = carPictureRepository;
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            var entity = await _carRepository.GetAsync(id);

            if (entity == null)
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");

            return _mapper.Map<CarEntity, CarModel>(entity);
        }

        public async Task<(List<CarModel>, int)> GetPageListAsync(CarQueryModel queryModel)
        {
            if (!queryModel.IsValidPagination)
            {
                throw new BadRequestException("Pagination rule is not valid");
            }

            var query = new QueryParameters<CarEntity>
            {
                FilterRule = GetFilterRule(queryModel),
                PaginationRule = GetPaginationRule(queryModel)
            };

            var paginationResult = await _carRepository.GetPageListAsync(query);

            var carModels = _mapper.Map<List<CarEntity>, List<CarModel>>(paginationResult.Items);

            return (carModels, paginationResult.TotalItemsCount);
        }

        public async Task CreateAsync(CarModel addCarModel)
        {
            if (!await _rentalPointRepository.ExistsAsync(addCarModel.RentalPointId))
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
            entityToUpdate.Color = updatedEntity.Color;
            entityToUpdate.NumberOfSeats = updatedEntity.NumberOfSeats;
            entityToUpdate.TransmissionType = updatedEntity.TransmissionType;
            entityToUpdate.FuelConsumptionPerHundredKilometers = updatedEntity.FuelConsumptionPerHundredKilometers;

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

        protected virtual FilterRule<CarEntity> GetFilterRule(CarQueryModel carModel) =>
            new FilterRule<CarEntity>
            {
                FilterExpression = car =>
                    (carModel.KeyReceivingTime != null && carModel.KeyHandOverTime != null && car.Bookings.AsQueryable()
                         .Count(booking => 
                             !(booking.KeyReceivingTime > carModel.KeyReceivingTime && booking.KeyReceivingTime > carModel.KeyHandOverTime ||
                               booking.KeyHandOverTime < carModel.KeyReceivingTime && booking.KeyHandOverTime < carModel.KeyHandOverTime)) == 0 ||
                     carModel.KeyReceivingTime == null || carModel.KeyHandOverTime == null) &&
                    (carModel.Brand != null && car.Brand.Contains(carModel.Brand) || carModel.Brand == null) &&
                    (carModel.Color != null && car.Color == carModel.Color || carModel.Color == null) &&
                    (carModel.MaxPricePerDay != null && car.PricePerDay < carModel.MaxPricePerDay || carModel.MaxPricePerDay == null) &&
                    (carModel.MinPricePerDay != null && car.PricePerDay > carModel.MinPricePerDay || carModel.MinPricePerDay == null) &&
                    (carModel.RentalPointId != null && car.RentalPointId == carModel.RentalPointId || carModel.RentalPointId == null) 
            };

        protected virtual PaginationRule GetPaginationRule(CarQueryModel carModel) => new PaginationRule
        {
            Index = carModel.PageIndex,
            Size = carModel.PageSize
        };
    }
}