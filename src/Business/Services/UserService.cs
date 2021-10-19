using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Interfaces;
using Business.Models;

namespace Business.Services
{
    public class UserService : IUserService
    {
        public Task<int> Count(UserFilterModel userFilterModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserModel>> GetListAsync(UserFilterModel userFilterModel)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserModel>> GetPageListAsync(UserFilterModel userFilterModel)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
