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
    public class AdditionalFacilityService : IAdditionalFacilityService
    {
        private readonly ApplicationContext _context;
        private readonly IAdditionalFacilityRepository _additionalFacilityRepository;
        private readonly IMapper _mapper;

        public AdditionalFacilityService(IMapper mapper, ApplicationContext context, IAdditionalFacilityRepository additionalFacilityRepository)
        {
            _mapper = mapper;
            _context = context;
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

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AdditionalFacilityModel additionalFacilityModel)
        {
            var entity = _mapper.Map<AdditionalFacilityModel, AdditionalFacilityEntity>(additionalFacilityModel);

            _additionalFacilityRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _additionalFacilityRepository.DeleteAsync(id);

            if (entity == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }
    }
}