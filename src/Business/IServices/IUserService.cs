using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllAsync();
        Task UpdateAsync(Guid id, UserModel user);
    }
}