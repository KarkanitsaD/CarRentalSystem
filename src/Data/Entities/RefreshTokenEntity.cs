using System;

namespace Data.Entities
{
    public class RefreshTokenEntity : Entity
    {
        public UserEntity User { get; set; }
        public string Token { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsRevoked { get; set; }
    }
}