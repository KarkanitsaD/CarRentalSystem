using System;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
    }
}