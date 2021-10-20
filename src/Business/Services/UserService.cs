using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserModel Get(Guid id)
        {
            var entity = _userRepository.Get(id);

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

            await _userRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}