using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(Guid id);
        IEnumerable<UserModel> GetList();
        Task CreateAsync(UserModel userModel);
        Task UpdateAsync(Guid id, UserModel userModel);
        Task DeleteAsync(Guid id);
    }
}