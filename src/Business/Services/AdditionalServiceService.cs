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
    public class AdditionalServiceService : IAdditionalServiceService
    {
        private readonly ApplicationContext _context;
        private readonly IAdditionalServiceRepository _additionalServiceRepository;
        private readonly IMapper _mapper;

        public AdditionalServiceService(IMapper mapper, ApplicationContext context, IAdditionalServiceRepository additionalServiceRepository)
        {
            _mapper = mapper;
            _context = context;
            _additionalServiceRepository = additionalServiceRepository;
        }

        public async Task<IList<AdditionalServiceModel>> GetListAsync()
        {
            var entities = await _additionalServiceRepository.GetListAsync();

            return _mapper.Map<IList<AdditionalServiceEntity>, IList<AdditionalServiceModel>>(entities);
        }

        public async Task CreateAsync(AdditionalServiceModel additionalServiceModel)
        {
            var entity = _mapper.Map<AdditionalServiceModel, AdditionalServiceEntity>(additionalServiceModel);

            await _additionalServiceRepository.CreateAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AdditionalServiceModel additionalServiceModel)
        {
            var entity = _mapper.Map<AdditionalServiceModel, AdditionalServiceEntity>(additionalServiceModel);

            _additionalServiceRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _additionalServiceRepository.DeleteAsync(id);

            if (entity == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }
    }
}
