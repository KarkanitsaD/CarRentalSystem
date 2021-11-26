﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Query;

namespace Data.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetAsync(Guid id);
        Task DeleteAsync(TEntity id);
        Task<int> CountAsync(FilterRule<TEntity> filterRule = null);
        Task<TEntity> GetAsync(FilterRule<TEntity> filterRule = null);
        Task<List<TEntity>> GetListAsync(QueryParameters<TEntity> queryParameters = null);
        Task<PageResult<TEntity>> GetPageListAsync(QueryParameters<TEntity> queryParameters);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> ExistsAsync(FilterRule<TEntity> filterRule);
        Task<bool> ExistsAsync(Guid id);
    }
}