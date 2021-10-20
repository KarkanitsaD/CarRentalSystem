using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly ICarRepository _carRepository;

        public CarService(IMapper mapper, ApplicationContext context, ICarRepository carRepository)
        {
            _mapper = mapper;
            _context = context;
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

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CarModel carModel)
        {
            var entity = _mapper.Map<CarModel, CarEntity>(carModel);

            _carRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async  Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _carRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");


            await _context.SaveChangesAsync();
        }
    }
}
