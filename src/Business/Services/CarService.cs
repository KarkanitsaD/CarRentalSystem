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
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ICarRepository _carRepository;

        public CarService(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<CarModel> GetAsync(Guid id)
        {
            var entity = await _carRepository.GetAsync(id);

            return _mapper.Map<CarEntity, CarModel>(entity);
        }

        public async Task<IList<CarModel>> GetListAsync()
        {
            var entities = await _carRepository.GetListAsync();

            return _mapper.Map<IList<CarEntity>, IList<CarModel>>(entities);
        }

        public async Task CreateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            await _carRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            _carRepository.Update(entity);
        }

        public async  Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _carRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");
        }
    }
}