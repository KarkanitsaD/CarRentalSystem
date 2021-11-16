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
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;
        private readonly IRentalPointRepository _rentalPointRepository;

        public CarService(IMapper mapper, ICarRepository carRepository, IRentalPointRepository rentalPointRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _rentalPointRepository = rentalPointRepository;
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            var entity = await _carRepository.GetAsync(id);

            if (entity == null)
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");

            return _mapper.Map<CarEntity, CarModel>(entity);
        }

        public IEnumerable<CarModel> GetList()
        {
            var entities = _carRepository.GetList();

            return _mapper.Map<IEnumerable<CarEntity>, IEnumerable<CarModel>>(entities);
        }

        public async Task CreateAsync(CarModel addCarModel)
        {
            if (!await _rentalPointRepository.ExistsAsync(addCarModel.RentalPointId))
            {
                throw new BadRequestException("Invalid rental point Id");
            }

            var carEntity = _mapper.Map<CarModel, CarEntity>(addCarModel);
            var carPicture = _mapper.Map<CarModel, CarPictureEntity>(addCarModel);

            carEntity.Picture = carPicture;

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
            var carPictureEntity = _mapper.Map<CarModel, CarPictureEntity>(carModel);

            entityToUpdate.RentalPointId = updatedEntity.RentalPointId;
            entityToUpdate.PricePerDay = updatedEntity.PricePerDay;
            entityToUpdate.CarBrand = updatedEntity.CarBrand;
            entityToUpdate.Color = updatedEntity.Color;
            entityToUpdate.NumberOfSeats = updatedEntity.NumberOfSeats;
            entityToUpdate.TransmissionType = updatedEntity.TransmissionType;
            entityToUpdate.FuelConsumptionPerHundredKilometers = updatedEntity.FuelConsumptionPerHundredKilometers;
            
            await _carRepository.UpdateAsync(entityToUpdate);
        }

        public async  Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _carRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _carRepository.DeleteAsync(entityToDelete);
        }
    }
}