using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.IServices;
using Business.Models;
using Data.Entities;
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

        public async Task<UserModel> GetAsync(Guid id)
        {
            var entity = await _userRepository.GetAsync(id);

            if (entity == null)
                throw new NotFoundException($"{nameof(entity)} with id = {id} not found.");

            return _mapper.Map<UserEntity, UserModel>(entity);
        }


        public async Task CreateAsync(UserModel userModel)
        {
            var entityToCreate = _mapper.Map<UserModel, UserEntity>(userModel);

            await _userRepository.CreateAsync(entityToCreate);
        }

        public async Task UpdateAsync(Guid id, UserModel userModel)
        {
            if (id != userModel.Id)
                throw new BadRequestException("Check data.");

            var entityToUpdate = await _userRepository.GetAsync(id);

            if (entityToUpdate == null)
                throw new NotFoundException($"{nameof(userModel)} with id = {id} not found.");

            entityToUpdate.Email = userModel.Email;
            entityToUpdate.Name = userModel.Name;
            entityToUpdate.Surname = userModel.Surname;

            await _userRepository.UpdateAsync(entityToUpdate);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _userRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _userRepository.DeleteAsync(entityToDelete);
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var users = await _userRepository.GetListAsync();

            return _mapper.Map<List<UserEntity>, List<UserModel>>(users);
        }
    }
}