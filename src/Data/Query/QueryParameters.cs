using Data.Entities;

namespace Data.Query
{
    public class QueryParameters<TEntity> where TEntity : Entity
    {
        public FilterRule<TEntity> FilterRule { get; set; }
        public PaginationRule PaginationRule { get; set; }
    }
}