﻿using System;
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

        public TEntity Get(Guid id)
        {
            return DbSet.Find(id);
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

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var updatedEntity = DbSet.Update(entity);

            await ApplicationContext.SaveChangesAsync();

            return updatedEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entityToDelete = DbSet.Find(id);

            if (entityToDelete == null)
                throw new KeyNotFoundException($"{nameof(TEntity)} with Id = {id} was not found.");

            var deletedEntity = DbSet.Remove(entityToDelete).Entity;

            await ApplicationContext.SaveChangesAsync();

            return deletedEntity;
        }
    }
}