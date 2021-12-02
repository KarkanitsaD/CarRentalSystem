using System;
using API.Models.Request.Role;

namespace API.Models.Request.User
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleRequest Role { get; set; }
    }
}