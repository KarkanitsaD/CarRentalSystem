using System.Collections.Generic;

namespace Data.Models
{
    public class RoleEntity : Entity<int>
    {
        public string Title { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
