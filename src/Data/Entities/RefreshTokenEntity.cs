using System;

namespace Data.Entities
{
    public class RefreshTokenEntity : Entity
    {
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsExpired => DateTime.Now > ExpirationTime;
        public bool IsRevoked { get; set; }
        public bool IsActive => !IsRevoked && IsExpired;
    }
}