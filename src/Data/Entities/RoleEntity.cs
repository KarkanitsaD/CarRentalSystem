using System.Collections.Generic;

namespace Data.Entities
{
    public class RoleEntity : Entity<int>
    {
        public string Title { get; set; }

        public ICollection<UserEntity> Users { get; set; }
    }
}