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
    public class RentalPointService : IRentalPointService
    {
        private readonly IMapper _mapper;
        private readonly IRentalPointRepository _rentalPointRepository;

        public RentalPointService(IMapper mapper, IRentalPointRepository rentalPointRepository)
        {
            _mapper = mapper;
            _rentalPointRepository = rentalPointRepository;
        }

        public RentalPointModel Get(Guid id)
        {
            var entity = _rentalPointRepository.Get(id);

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

        public async Task UpdateAsync(RentalPointModel rentalPointModel)
        {
            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);

            await _rentalPointRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _rentalPointRepository.DeleteAsync(id);
        }
    }
}