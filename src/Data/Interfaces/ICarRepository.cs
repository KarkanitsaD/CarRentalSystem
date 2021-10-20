using System;
using Data.Entities;

namespace Data.Interfaces
{
    public interface ICarRepository : IRepository<CarEntity, Guid>
    {

    }
}