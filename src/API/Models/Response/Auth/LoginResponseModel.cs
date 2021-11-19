using System;

namespace API.Models.Response.Auth
{
    public class LoginResponseModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
        public string[] Roles { get; set; }
    }
}