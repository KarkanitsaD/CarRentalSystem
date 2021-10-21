using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : Entity
    {

        protected ApplicationContext ApplicationContext;

        protected BaseRepository(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
            DbSet = ApplicationContext.Set<TEntity>();
        }

        protected readonly DbSet<TEntity> DbSet;

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> GetList()
        {
            return DbSet.AsEnumerable();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = DbSet.Add(entity);

            await ApplicationContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);

            await ApplicationContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
            await ApplicationContext.SaveChangesAsync();
        }
    }
}