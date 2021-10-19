using System;
using Data.Interfaces;
using Data.Models;

namespace Data.Repositories
{
    public class UserRepository : Repository<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
            : base(context)
        {

        }
    }
}
