using System;
using Data.Models;

namespace Data.Interfaces
{
    public interface ICarRepository : IRepository<CarEntity, Guid>
    {

    }
}
