using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task CreateAsync(RoleModel roleBusinessModel);
        Task UpdateAsync(RoleModel roleBusinessModel);
        Task DeleteAsync(int id);
    }
}
