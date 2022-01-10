using System;
using System.Threading.Tasks;
using Data.Entities;
using Data.Query;
using Data.Query.FiltrationModels;

namespace Data.IRepositories
{
    public interface ICarRepository : IBaseRepository<CarEntity>
    {
        Task<PageResult<CarEntity>> GetPageListAsync(Guid? userId, CarFiltrationModel carFiltrationModel, int pageIndex, int pageSize);
        Task<CarEntity> GetWithCarLockAsync(Guid carId);
    }
}