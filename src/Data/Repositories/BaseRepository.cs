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

        private readonly CarRentalSystemContext _carRentalSystemContext;

        protected BaseRepository(CarRentalSystemContext carRentalSystemContext)
        {
            _carRentalSystemContext = carRentalSystemContext;
            DbSet = _carRentalSystemContext.Set<TEntity>();
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

            await _carRentalSystemContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);

            await _carRentalSystemContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entityToDelete)
        {
            DbSet.Remove(entityToDelete);
            await _carRentalSystemContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await DbSet.FindAsync(id) != null;
        }
    }
}