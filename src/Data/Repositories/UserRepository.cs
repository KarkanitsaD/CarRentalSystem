using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(CarRentalSystemContext context)
            : base(context)
        {
        }

        public async Task<UserEntity> GetByAsync(string email, string password)
        {
            return await DbSet.Include(user => user.Roles).Include(user => user.RefreshToken)
                .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == password);
        }

        public async Task<UserEntity> GetByAsync(string email)
        {
            return await DbSet
                .FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}