using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Exceptions;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;
using Data;
using Data.Entities;
using Data.Interfaces;
using Data.Query;

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

        public async Task<int> Count(UserFilterModel userFilterModel)
        {
            var filterRule = DefineFilterRule(userFilterModel);
            return await _userRepository.Count(filterRule);
        }

        public async Task<UserModel> GetAsync(Guid id)
        {
            var filterRule = new FilterRule<UserEntity, Guid>
            {
                FilterExpression = user => user.Id == id
            };

            var entity = await _userRepository.GetAsync(filterRule);

            return _mapper.Map<UserEntity, UserModel>(entity);
        }

        public async Task<IList<UserModel>> GetListAsync(UserFilterModel userFilterModel)
        {
            var filterRule = DefineFilterRule(userFilterModel);
            var sortRule = DefineSortRule(userFilterModel);
            var queryParameters = new QueryParameters<UserEntity, Guid>
            {
                FilterRule = filterRule,
                SortRule = sortRule
            };

            var userEntities = await _userRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<UserEntity>, IList<UserModel>>(userEntities);
        }

        public async Task<IList<UserModel>> GetPageListAsync(UserFilterModel userFilterModel)
        {
            var filterRule = DefineFilterRule(userFilterModel);
            var sortRule = DefineSortRule(userFilterModel);
            var queryParameters = new QueryParameters<UserEntity, Guid>()
            {
                FilterRule = filterRule,
                SortRule = sortRule,
                PaginationRule = new PaginationRule()
                {
                    Index = userFilterModel.PageIndex,
                    Size = userFilterModel.PageSize
                }
            };

            var entities = await _userRepository.GetPageListAsync(queryParameters);

            return _mapper.Map<IList<UserEntity>, IList<UserModel>>(entities);
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


        private FilterRule<UserEntity, Guid> DefineFilterRule(UserFilterModel userFilterModel)
        {
            var filterRule = new FilterRule<UserEntity, Guid>
            {
                FilterExpression = user =>
                    (!string.IsNullOrEmpty(userFilterModel.Email) && user.Email == userFilterModel.Email || string.IsNullOrEmpty(userFilterModel.Email)) &&
                    (!string.IsNullOrEmpty(userFilterModel.Name) && user.Name == userFilterModel.Name || string.IsNullOrEmpty(userFilterModel.Name)) &&
                    (!string.IsNullOrEmpty(userFilterModel.Surname) && user.Surname == userFilterModel.Surname || string.IsNullOrEmpty(userFilterModel.Surname)) &&
                    (userFilterModel.NumberOfOrders != null && user.Orders.Count == userFilterModel.NumberOfOrders || userFilterModel.NumberOfOrders == null)
            };

            return filterRule;
        }

        private SortRule<UserEntity, Guid> DefineSortRule(UserFilterModel userFilterModel)
        {
            var sortRule = new SortRule<UserEntity, Guid>();

            if (userFilterModel.InAscendingOrder != null)
            {
                sortRule.InAscendingOrder = (bool)userFilterModel.InAscendingOrder;
                sortRule.SortExpression = user => user.Name;
            }

            return sortRule;
        }
    }
}
