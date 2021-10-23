using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
            : base(context)
        {
        }

        public override async Task<UserEntity> GetAsync(Guid id)
        {
            return await DbSet.Include(user => user.Roles).FirstAsync(user => user.Id == id);
        }

        public async Task<UserEntity> GetByEmailAndPassword(string email, string password)
        {
            return await DbSet.Include(user => user.Roles)
                .FirstOrDefaultAsync(user => user.Email == email && user.PasswordHash == password);
        }
    }
}