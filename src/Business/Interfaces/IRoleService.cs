using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task CreateAsync(RoleModel roleModel);
        Task UpdateAsync(RoleModel roleModel);
        Task DeleteAsync(int id);
    }
}