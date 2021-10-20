﻿using System;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {

    }
}
