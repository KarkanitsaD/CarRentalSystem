using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public CarService(IMapper mapper, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public CarModel Get(Guid id)
        {
            var entity = _carRepository.GetAsync(id);

            return _mapper.Map<CarEntity, CarModel>(entity);
        }

        public IEnumerable<CarModel> GetList()
        {
            var entities = _carRepository.GetList();

            return _mapper.Map<IEnumerable<CarEntity>, IEnumerable<CarModel>>(entities);
        }

        public async Task CreateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            await _carRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            await _carRepository.UpdateAsync(entity);
        }

        public async  Task DeleteAsync(Guid id)
        {
            await _carRepository.DeleteAsync(id);
        }
    }
}