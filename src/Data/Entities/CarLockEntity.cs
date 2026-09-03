using System;

namespace Data.Entities
{
    public class CarLockEntity : Entity
    {
        public DateTime LockTime { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}