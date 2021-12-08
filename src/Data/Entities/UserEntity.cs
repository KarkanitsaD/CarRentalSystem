using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class UserEntity : Entity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid? RoleId { get; set; }
        public RoleEntity Role { get; set; }
        public RefreshTokenEntity RefreshToken { get; set; }
        public CarLockEntity CarLockEntity { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; }
    }
}