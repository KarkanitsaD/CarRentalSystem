using System;
using System.Linq.Expressions;
using Data.Interfaces;

namespace Data.Query
{
    public class FilterRule<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> FilterExpression { get; set; }
    }
}
