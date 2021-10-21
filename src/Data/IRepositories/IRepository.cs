using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Data.IRepositories
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetList();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TKey id);
    }
}