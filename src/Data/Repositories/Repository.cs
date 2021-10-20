using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly DbSet<TEntity> Set;

        protected Repository(ApplicationContext context)
        {
            Set = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await Set.AsQueryable().FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public async Task<IList<TEntity>> GetListAsync()
        {
            return await Set.AsQueryable().ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await Set.AddAsync(entity);

            return createdEntity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var updatedEntity = Set.Update(entity);

            return updatedEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(TKey id)
        {
            var entityToDelete = await Set.FindAsync(id);

            if (entityToDelete != null)
                return Set.Remove(entityToDelete).Entity;
            
            return null;
        }
    }
}
