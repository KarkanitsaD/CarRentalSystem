using System;
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
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, ApplicationContext context, IUserRepository userRepository)
        {
            _mapper = mapper;
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<UserModel> GetAsync(Guid id)
        {
            var entity = await _userRepository.GetAsync(id);

            return _mapper.Map<UserEntity, UserModel>(entity);
        }

        public async Task<IList<UserModel>> GetListAsync()
        {
            var userEntities = await _userRepository.GetListAsync();

            return _mapper.Map<IList<UserEntity>, IList<UserModel>>(userEntities);
        }


        public async Task CreateAsync(UserModel userModel)
        {
            var entityToCreate = _mapper.Map<UserModel, UserEntity>(userModel);

            await _userRepository.CreateAsync(entityToCreate);
        }

        public async Task UpdateAsync(UserModel userModel)
        {
            var entityToUpdate = _mapper.Map<UserModel, UserEntity>(userModel);

            _userRepository.Update(entityToUpdate);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _userRepository.DeleteAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException("Entity not found.");
            await _context.SaveChangesAsync();
        }
    }
}
