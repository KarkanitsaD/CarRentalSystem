using System;

namespace API.Models.Response.User
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string[] Roles { get; set; }
    }
}