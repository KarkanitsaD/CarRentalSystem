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
    public class RentalPointService : IRentalPointService
    {
        private readonly IMapper _mapper;
        private readonly IRentalPointRepository _rentalPointRepository;

        public RentalPointService(IMapper mapper, IRentalPointRepository rentalPointRepository)
        {
            _mapper = mapper;
            _rentalPointRepository = rentalPointRepository;
        }

        public async Task<RentalPointModel> GetAsync(Guid id)
        {
            var entity = await _rentalPointRepository.GetAsync(id);

            return _mapper.Map<RentalPointEntity, RentalPointModel>(entity);
        }

        public IEnumerable<RentalPointModel> GetList()
        {
            var entities = _rentalPointRepository.GetList();

            return _mapper.Map<IEnumerable<RentalPointEntity>, IEnumerable<RentalPointModel>>(entities);
        }

        public async Task CreateAsync(RentalPointModel rentalPointModel)
        {
            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);

            await _rentalPointRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid id, RentalPointModel rentalPointModel)
        {
            if (id != rentalPointModel.Id)
                throw new BadRequestException("Check data.");

            var entityToUpdate = await _rentalPointRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(rentalPointModel)} with id = {id} not found.");

            entityToUpdate = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);

            await _rentalPointRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _rentalPointRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _rentalPointRepository.DeleteAsync(entityToDelete);
        }
    }
}