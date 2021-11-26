using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Query;

namespace Business.IServices
{
    public interface IUserService
    {
        Task<(List<UserModel>, int)> GetPageListAsync(UserQueryModel userModel);
        Task UpdateAsync(Guid id, UserModel user);
        Task CreateUser(CreateUserModel userModel);
        Task DeleteAsync(Guid id);
    }
}