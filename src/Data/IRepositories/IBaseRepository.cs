using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : Entity
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetList();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(Guid id);
    }
}