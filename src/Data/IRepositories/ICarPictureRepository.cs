using System;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface ICarPictureRepository : IBaseRepository<CarPictureEntity>
    {
        Task<CarPictureEntity> GetByCarIdAsync(Guid carId);
    }
}