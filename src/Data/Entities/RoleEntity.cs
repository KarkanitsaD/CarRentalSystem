using System.Collections.Generic;

namespace Data.Entities
{
    public class RoleEntity : Entity
    {
        public string Title { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}