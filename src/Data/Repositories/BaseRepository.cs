using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : Entity
    {

        private readonly CarRentalSystemContext _carRentalSystemContext;

        protected BaseRepository(CarRentalSystemContext carRentalSystemContext)
        {
            _carRentalSystemContext = carRentalSystemContext;
            DbSet = _carRentalSystemContext.Set<TEntity>();
        }

        protected readonly DbSet<TEntity> DbSet;

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>>GetListAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = DbSet.Add(entity);

            await _carRentalSystemContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = DbSet.Update(entity).Entity;

            await _carRentalSystemContext.SaveChangesAsync();

            return updatedEntity;
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
            await _carRentalSystemContext.SaveChangesAsync();
        }
    }
}