using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class UserEntity : Entity<Guid>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
