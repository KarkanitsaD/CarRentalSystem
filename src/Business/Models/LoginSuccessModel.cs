using System;
using System.Linq;
using Data.Entities;

namespace Business.Models
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(UserEntity user, string jwt, string refreshToken)
        {
            Id = user.Id;
            Email = user.Email;
            Name = user.Name;
            Jwt = jwt;
            RefreshToken = refreshToken;
            Roles = user.Roles.Select(role => role.Title).ToArray();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
        public string[] Roles { get; set; }
    }
}