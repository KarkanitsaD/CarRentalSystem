using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IUserService
    {
        UserModel Get(Guid id);
        IEnumerable<UserModel> GetList();
        Task CreateAsync(UserModel userModel);
        Task UpdateAsync(UserModel userModel);
        Task DeleteAsync(Guid id);
    }
}