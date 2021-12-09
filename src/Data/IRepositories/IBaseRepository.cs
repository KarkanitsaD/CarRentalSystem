using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetAsync(Guid id);
        Task<List<TEntity>> GetListAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}