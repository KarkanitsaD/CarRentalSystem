using System;
using System.Collections.Generic;
using API.Models.Response.Role;

namespace API.Models.Response.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleResponse Role { get; set; }
    }
}