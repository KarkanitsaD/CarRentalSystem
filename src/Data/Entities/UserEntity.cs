using System.Collections.Generic;

namespace Data.Entities
{
    public class UserEntity : Entity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RefreshTokenEntity RefreshToken { get; set; }
        public ICollection<RoleEntity> Roles { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; }
    }
}