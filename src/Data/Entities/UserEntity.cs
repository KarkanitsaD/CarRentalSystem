﻿using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class UserEntity : Entity<Guid>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }
        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}