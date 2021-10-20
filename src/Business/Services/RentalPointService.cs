﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

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

        public RentalPointModel Get(int id)
        {
            var entity = _rentalPointRepository.Get(id);

            return _mapper.Map<RentalPointEntity, RentalPointModel>(entity);
        }

        public async Task<IList<RentalPointModel>> GetListAsync()
        {
            var entities = await _rentalPointRepository.GetListAsync();

            return _mapper.Map<IList<RentalPointEntity>, IList<RentalPointModel>>(entities);
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

        public async Task DeleteAsync(int id)
        {
            await _rentalPointRepository.DeleteAsync(id);
        }
    }
}