using System;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface ICarRepository : IBaseRepository<CarEntity>
    {
        Task<CarEntity> GetWithCarLockAsync(Guid carId);
    }
}