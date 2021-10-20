using System.Collections.Generic;

namespace Data.Entities
{
    public class AdditionalServiceEntity : Entity<int>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
