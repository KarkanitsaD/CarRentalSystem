using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<RoleModel> Roles { get; set; }
        public ICollection<BookingModel> Bookings { get; set; }
    }
}