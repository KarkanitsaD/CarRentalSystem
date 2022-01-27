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


        public AdditionalFacilityService(IAdditionalFacilityRepository additionalFacilityRepository, IMapper mapper)
        {
            _additionalFacilityRepository = additionalFacilityRepository;
            _mapper = mapper;
        }

        public async Task<List<AdditionalFacilityModel>> GetAllByRentalPointIdAsync(Guid rentalPointId)
        {
            var entities = await _additionalFacilityRepository.GetAllByRentalPointIdAsync(rentalPointId);
            return _mapper.Map<List<AdditionalFacilityEntity>, List<AdditionalFacilityModel>>(entities);
        }

        public async Task<AdditionalFacilityModel> CreateAsync(AdditionalFacilityModel createModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(createModel);
            entity = await _additionalFacilityRepository.CreateAsync(entity);
            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _additionalFacilityRepository.GetAsync(id);
            if (entityToDelete == null)
            {
                throw new NotFoundException("Additional facility with input id not found!");
            }

            await _additionalFacilityRepository.DeleteAsync(entityToDelete);
        }

        public async Task UpdateAsync(Guid id, AdditionalFacilityModel updateModel)
        {
            if (id != updateModel.Id)
            {
                throw new BadRequestException("Check data!");
            }

            var entityToUpdate = await _additionalFacilityRepository.GetAsync(id);

            if (entityToUpdate == null)
            {
                throw new NotFoundException("Additional facility with input id not found!");
            }

            entityToUpdate.Price = updateModel.Price;
            entityToUpdate.Title = updateModel.Title;
            await _additionalFacilityRepository.UpdateAsync(entityToUpdate);
        }
    }
}