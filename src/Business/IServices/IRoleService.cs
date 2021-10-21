using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.IServices
{
    public interface IRoleService
    {
        Task CreateAsync(RoleModel roleModel);
        Task UpdateAsync(Guid id, RoleModel roleModel);
        Task DeleteAsync(Guid id);
    }
}