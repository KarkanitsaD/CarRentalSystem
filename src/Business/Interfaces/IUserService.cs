﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> GetAsync(Guid id);
        Task<IList<UserModel>> GetListAsync();
        Task CreateAsync(UserModel userModel);
        Task UpdateAsync(UserModel userModel);
        Task DeleteAsync(Guid id);
    }
}
