using System;
using System.Linq.Expressions;
using Data.Entities;

namespace Data.Query
{
    public class FilterRule<TEntity> where TEntity: Entity
    {
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
    }
}