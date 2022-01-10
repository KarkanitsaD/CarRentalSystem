using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.Helpers;
using Business.IServices;
using Business.Models;
using Business.Query;
using Data.Entities;
using Data.IRepositories;
using Data.Query.FiltrationModels;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository, PasswordHasher passwordHasher)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
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
            entityToUpdate.RoleId = userModel.Role.Id;

            await _userRepository.UpdateAsync(entityToUpdate);
        }

        public async Task CreateUser(CreateUserModel userModel)
        {
            var user = await _userRepository.GetByEmailAsync(userModel.Email);

            if (user != null)
            {
                throw new NotAuthenticatedException("User with that credentials already exists.");
            }

            var role = _mapper.Map<RoleModel, RoleEntity>(userModel.Role);

            user = new UserEntity
            {
                Email = userModel.Email,
                Name = userModel.Name,
                Surname = userModel.Surname,
                RoleId = role.Id,
                PasswordHash = _passwordHasher.GeneratePasswordHash(userModel.Password)
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entityToDelete = await _userRepository.GetAsync(id);

            if (entityToDelete == null)
                throw new NotFoundException($"{nameof(entityToDelete)} with id = {id} not found.");

            await _userRepository.DeleteAsync(entityToDelete);
        }

        public async Task<(List<UserModel>, int)> GetPageListAsync(UserQueryModel queryModel)
        {
            if (!queryModel.IsValidPagination)
            {
                throw new BadRequestException("Pagination rule is not valid");
            }
            
            var userFilter = _mapper.Map<UserQueryModel, UserFiltrationModel>(queryModel);
            var paginationResult = await _userRepository.GetPageListAsync(userFilter, queryModel.PageIndex, queryModel.PageSize);

            var userModels = _mapper.Map<List<UserEntity>, List<UserModel>>(paginationResult.Items);

            return (userModels, paginationResult.TotalItemsCount);
        }
    }
}