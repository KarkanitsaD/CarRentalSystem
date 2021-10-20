using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

        protected ApplicationContext ApplicationContext;

        protected Repository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DbSet = ApplicationContext.Set<TEntity>();
        }

        protected readonly DbSet<TEntity> DbSet;

        public async Task<TEntity> GetAsync(TKey id)
        {
            return await DbSet.AsQueryable().FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public async Task<IList<TEntity>> GetListAsync()
        {
            return await DbSet.AsQueryable().ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await DbSet.AddAsync(entity);

            await ApplicationContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = DbSet.Update(entity);

            await ApplicationContext.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(TKey id)
        {
            var entityToDelete = await DbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                var deletedEntity = DbSet.Remove(entityToDelete).Entity;
                await ApplicationContext.SaveChangesAsync();

                return deletedEntity;
            }

            return null;
        }
    }
}