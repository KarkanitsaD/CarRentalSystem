﻿using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IRoleService
    {
        Task CreateAsync(RoleModel roleModel);
        Task UpdateAsync(RoleModel roleModel);
        Task DeleteAsync(Guid id);
    }
}