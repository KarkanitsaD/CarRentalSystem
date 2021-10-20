using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<IList<TEntity>> GetListAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> DeleteAsync(TKey id);
    }
}