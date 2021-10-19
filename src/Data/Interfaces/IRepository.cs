using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Query;

namespace Data.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<int> Count(FilterRule<TEntity, TKey> filterRule = null);
        Task<TEntity> GetAsync(FilterRule<TEntity, TKey> filterRule = null);
        Task<IList<TEntity>> GetListAsync(QueryParameters<TEntity, TKey> queryParameters = null);
        Task<IList<TEntity>> GetPageListAsync(QueryParameters<TEntity, TKey> queryParameters = null);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> DeleteAsync(TKey id);
    }
}
