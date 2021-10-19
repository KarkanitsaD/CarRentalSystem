using Data.Interfaces;

namespace Data.Query
{
    public class QueryParameters<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        public FilterRule<TEntity, TKey> FilterRule { get; set; }
        public SortRule<TEntity, TKey> SortRule { get; set; }
        public PaginationRule PaginationRule { get; set; }
    }
}
