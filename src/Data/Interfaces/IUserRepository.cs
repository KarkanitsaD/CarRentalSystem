using System;
using Data.Models;

namespace Data.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {

    }
}
