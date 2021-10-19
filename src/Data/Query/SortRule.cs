using System;
using System.Linq.Expressions;
using Data.Interfaces;

namespace Data.Query
{
    public class SortRule<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public Expression<Func<TEntity, object>> SortExpression { get; set; }

        public bool InAscendingOrder { get; set; } = true;
    }
}
