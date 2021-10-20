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
    public class RentalPointService : IRentalPointService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IRentalPointRepository _rentalPointRepository;

        public RentalPointService(IMapper mapper, ApplicationContext context, IRentalPointRepository rentalPointRepository)
        {
            _mapper = mapper;
            _context = context;
            _rentalPointRepository = rentalPointRepository;
        }

        public async Task<RentalPointModel> GetAsync(int id)
        {
            var entity = await _rentalPointRepository.GetAsync(id);

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

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RentalPointModel rentalPointModel)
        {
            var entity = _mapper.Map<RentalPointModel, RentalPointEntity>(rentalPointModel);

            _rentalPointRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _rentalPointRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }
    }
}