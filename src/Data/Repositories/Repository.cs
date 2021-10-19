using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Query;
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

        public virtual async Task<int> Count(FilterRule<TEntity, TKey> filterRule = null)
        {
            var query = Set.AsQueryable();

            if (filterRule == null)
                return await query.CountAsync();

            return await FilterQuery(query, filterRule).CountAsync();
        }

        public virtual async Task<TEntity> GetAsync(FilterRule<TEntity, TKey> filterRule = null)
        {
            var query = Set.AsQueryable();

            if (filterRule == null)
                return await query.FirstOrDefaultAsync();

            return await FilterQuery(query, filterRule).FirstOrDefaultAsync();
        }

        public virtual async Task<IList<TEntity>> GetListAsync(QueryParameters<TEntity, TKey> queryParameters = null)
        {
            var query = Set.AsQueryable();

            if (queryParameters == null)
                return await query.ToListAsync();

            query = BaseQuery(query, queryParameters);

            return await query.ToListAsync();
        }

        public virtual async Task<IList<TEntity>> GetPageListAsync(QueryParameters<TEntity, TKey> queryParameters = null)
        {
            var query = Set.AsQueryable();

            if (queryParameters == null)
                return await query.ToListAsync();

            query = BaseQuery(query, queryParameters);

            if (queryParameters.PaginationRule != null)
                query = PaginationQuery(query, queryParameters.PaginationRule);

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await Set.AddAsync(entity);
            return result.Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var result = Set.Update(entity);
            return result.Entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TKey id)
        {
            var entityToDelete = await Set.FindAsync(id);

            if (entityToDelete != null)
            {
                Set.Remove(entityToDelete);
            }

            return entityToDelete;
        }

        protected virtual IQueryable<TEntity> BaseQuery(IQueryable<TEntity> queryable, QueryParameters<TEntity, TKey> queryParameters)
        {
            if (queryParameters.FilterRule?.FilterExpression != null)
                queryable = FilterQuery(queryable, queryParameters.FilterRule);

            if (queryParameters.SortRule?.SortExpression != null)
                queryable = SortQuery(queryable, queryParameters.SortRule);

            return queryable;
        }

        protected virtual IQueryable<TEntity> FilterQuery(IQueryable<TEntity> queryable, FilterRule<TEntity, TKey> filterRule)
        {
            queryable = queryable.Where(filterRule.FilterExpression);

            return queryable;
        }

        protected virtual IQueryable<TEntity> SortQuery(IQueryable<TEntity> queryable, SortRule<TEntity, TKey> sortRule)
        {
            queryable = sortRule.InAscendingOrder
                    ? queryable.OrderBy(sortRule.SortExpression)
                    : queryable.OrderByDescending(sortRule.SortExpression);

            return queryable;
        }

        protected virtual IQueryable<TEntity> PaginationQuery(IQueryable<TEntity> queryable, PaginationRule paginationRule)
        {
            if (paginationRule == null)
                throw new ArgumentException("Pagination rule can't be null.", nameof(paginationRule));

            if (paginationRule.Index < 0 || paginationRule.Size <= 0)
                throw new ArgumentException("Pagination rule is not valid.", nameof(paginationRule));

            queryable = queryable.Skip(paginationRule.Index * paginationRule.Size).Take(paginationRule.Size);

            return queryable;
        }
    }
}
