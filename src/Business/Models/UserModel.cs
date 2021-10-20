using System;
using System.Collections.Generic;
using Data.Entities;

namespace Business.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<RoleModel> Roles { get; set; }
        public virtual ICollection<BookingEntity> Bookings { get; set; }
    }
}