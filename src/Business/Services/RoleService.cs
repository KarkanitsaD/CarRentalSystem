using System.Threading.Tasks;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
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

        public async Task UpdateAsync(RoleModel roleModel)
        {
            var entity = _mapper.Map<RoleModel, RoleEntity>(roleModel);

            await _roleRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
        }
    }
}