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
    public class AdditionalFacilityService : IAdditionalFacilityService
    {
        private readonly IAdditionalFacilityRepository _additionalFacilityRepository;
        private readonly IMapper _mapper;

        public AdditionalFacilityService(IMapper mapper, IAdditionalFacilityRepository additionalFacilityRepository)
        {
            _mapper = mapper;
            _additionalFacilityRepository = additionalFacilityRepository;
        }

        public async Task<IList<AdditionalFacilityModel>> GetListAsync()
        {
            var entities = await _additionalFacilityRepository.GetListAsync();

            return _mapper.Map<IList<AdditionalFacilityEntity>, IList<AdditionalFacilityModel>>(entities);
        }

        public async Task CreateAsync(AdditionalFacilityModel additionalFacilityModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            await _additionalFacilityRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(AdditionalFacilityModel additionalFacilityModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            _additionalFacilityRepository.Update(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _additionalFacilityRepository.DeleteAsync(id);

            if (entity == null)
                throw new NotFoundException("Entity not found.");
        }
    }
}