using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.IServices;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.IRepositories;

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

        public IEnumerable<UserModel> GetList()
        {
            var userEntities = _userRepository.GetList();

            return _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserModel>>(userEntities);
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