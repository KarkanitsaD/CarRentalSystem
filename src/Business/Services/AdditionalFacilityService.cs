using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task UpdateAsync(AdditionalFacilityModel additionalFacilityModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            await _additionalFacilityRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _additionalFacilityRepository.DeleteAsync(id);
        }
    }
}