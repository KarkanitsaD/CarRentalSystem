using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.IRepositories;

namespace Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task CreateAsync(RoleModel roleModel)
        {
            var entity = _mapper.Map<RoleModel, RoleEntity>(roleModel);

            await _roleRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(Guid id, RoleModel roleModel)
        {
            if (id != roleModel.Id)
                throw new BadRequestException("Check data.");

            var entityToUpdate = await _roleRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(roleModel)} with id = {id} not found.");

            entityToUpdate = _mapper.Map<RoleModel, RoleEntity>(roleModel);

            await _roleRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _roleRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _roleRepository.DeleteAsync(entityToDelete);
        }
    }
}