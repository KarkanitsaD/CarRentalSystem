using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.IRepositories;
using Data.Query;
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


        public async Task<bool> ExistsAsync(Guid id)
        {
            return await DbSet.FindAsync(id) != null;
        }

        public virtual async Task<int> CountAsync(FilterRule<TEntity> filterRule = null)
        {
            var query = DbSet.AsQueryable();

            if (filterRule == null)
            {
                return await query.CountAsync();
            }

            return await FilterQuery(query, filterRule).CountAsync();
        }

        public virtual async Task<bool> ExistsAsync(FilterRule<TEntity> filterRule)
        {
            return await CountAsync(filterRule) > 0;
        }

        public async Task<TEntity> GetAsync(FilterRule<TEntity> filterRule = null)
        {
            var query = DbSet.AsQueryable();

            if (filterRule == null)
            {
                return await query.FirstOrDefaultAsync();
            }

            return await FilterQuery(query, filterRule).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> GetListAsync(QueryParameters<TEntity> queryParameters = null)
        {
            var query = DbSet.AsQueryable();

            if (queryParameters == null)
                return await query.ToListAsync();

            query = BaseQuery(query, queryParameters);

            return await query.ToListAsync();
        }

        public virtual async Task<PageResult<TEntity>> GetPageListAsync(QueryParameters<TEntity> queryParameters)
        {
            var query = DbSet.AsQueryable();

            query = BaseQuery(query, queryParameters);

            int totalItemsCount = await query.CountAsync();

            if (queryParameters.PaginationRule != null)
            {
                query = PaginationQuery(query, queryParameters.PaginationRule);
            }

            var items = await query.ToListAsync();

            return new PageResult<TEntity>(items, totalItemsCount);
        }

        protected virtual IQueryable<TEntity> BaseQuery(IQueryable<TEntity> queryable,
            QueryParameters<TEntity> queryParameters)
        {
            if (queryParameters.FilterRule?.FilterExpression != null)
                queryable = FilterQuery(queryable, queryParameters.FilterRule);

            //add sort rule

            return queryable;
        }

        protected virtual IQueryable<TEntity> FilterQuery(IQueryable<TEntity> queryable, FilterRule<TEntity> filterRule)
        {
            queryable = queryable.Where(filterRule.FilterExpression);

            return queryable;
        }

        protected virtual IQueryable<TEntity> PaginationQuery(IQueryable<TEntity> queryable, PaginationRule paginationRule)
        {
            queryable = queryable.Skip(paginationRule.Index * paginationRule.Size).Take(paginationRule.Size);

            return queryable;
        }
    }
}