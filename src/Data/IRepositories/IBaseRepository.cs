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
        IEnumerable<TEntity> GetList();
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity id);
        Task<bool> ExistsAsync(Guid id);
    }
}