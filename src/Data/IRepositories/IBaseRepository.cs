using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Query;

namespace Data.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetAsync(Guid id);
        IEnumerable<TEntity> GetList();
        Task DeleteAsync(TEntity id);
        Task<bool> ExistsAsync(Guid id);


        Task<int> CountAsync(FilterRule<TEntity> filterRule = null);
        Task<TEntity> GetAsync(FilterRule<TEntity> filterRule = null);
        Task<List<TEntity>> GetListAsync(QueryParameters<TEntity> queryParameters = null);
        Task<PageResult<TEntity>> GetPageListAsync(QueryParameters<TEntity> queryParameters);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<bool> ExistsAsync(FilterRule<TEntity> filterRule);
    }
}