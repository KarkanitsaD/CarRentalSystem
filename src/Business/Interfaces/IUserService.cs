using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.FilterModels;
using Business.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<int> Count(UserFilterModel userFilterModel);
        Task<UserModel> GetAsync(Guid id);
        Task<IList<UserModel>> GetListAsync(UserFilterModel userFilterModel);
        Task<IList<UserModel>> GetPageListAsync(UserFilterModel userFilterModel);
        Task CreateAsync(UserModel userModel);
        Task UpdateAsync(UserModel userModel);
        Task DeleteAsync(Guid id);
    }
}
