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
    public class AdditionalFacilityService : IAdditionalFacilityService
    {
        private readonly IAdditionalFacilityRepository _additionalFacilityRepository;
        private readonly IMapper _mapper;

        public AdditionalFacilityService(IMapper mapper, IAdditionalFacilityRepository additionalFacilityRepository)
        {
            _mapper = mapper;
            _additionalFacilityRepository = additionalFacilityRepository;
        }

        public IEnumerable<AdditionalFacilityModel> GetList()
        {
            var entities = _additionalFacilityRepository.GetList();

            return _mapper.Map<IEnumerable<AdditionalFacilityEntity>, IEnumerable<AdditionalFacilityModel>>(entities);
        }

        public async Task CreateAsync(AdditionalFacilityModel additionalFacilityModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            await _additionalFacilityRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid id, AdditionalFacilityModel additionalFacilityModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            await _additionalFacilityRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _additionalFacilityRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _additionalFacilityRepository.DeleteAsync(entityToDelete);
        }
    }
}