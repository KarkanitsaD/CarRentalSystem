using System;
using Data.Entities;

namespace Data.IRepositories
{
    public interface ICarRepository : IBaseRepository<CarEntity, Guid>
    {

    }
}