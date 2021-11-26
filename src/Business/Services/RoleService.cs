using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task<List<RoleModel>> GetAllAsync()
        {
            var roles = await _roleRepository.GetListAsync();

            return _mapper.Map<List<RoleEntity>, List<RoleModel>>(roles);
        }
    }
}