using System.Collections.Generic;
using Data.Entities;

namespace Data.Query
{
    public class PageResult<TEntity> where TEntity : Entity
    {
        public PageResult(List<TEntity> items, int totalItemsCount)
        {
            Items = items;
            TotalItemsCount = totalItemsCount;
        }

        public List<TEntity> Items { get; set; }
        public int TotalItemsCount { get; set; }
    }
}