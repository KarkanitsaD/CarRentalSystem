using System;
using Data.Entities;
using Data.Interfaces;

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