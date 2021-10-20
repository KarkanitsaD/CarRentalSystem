using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Interfaces;
using Data.Models;

namespace Business.Services
{
    public class RoleService : IRoleService
    {

        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, ApplicationContext context, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _context = context;
            _roleRepository = roleRepository;
        }

        public async Task CreateAsync(RoleModel roleModel)
        {
            var entity = _mapper.Map<RoleModel, RoleEntity>(roleModel);

            await _roleRepository.CreateAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoleModel roleModel)
        {
            var entity = _mapper.Map<RoleModel, RoleEntity>(roleModel);

            _roleRepository.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _roleRepository.DeleteAsync(id);

            if (entity == null)
                throw new NotFoundException("Entity not found.");

            await _context.SaveChangesAsync();
        }
    }
}
