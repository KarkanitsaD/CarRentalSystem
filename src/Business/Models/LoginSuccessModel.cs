using System;
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
            Surname = user.Surname;
            Jwt = jwt;
            RefreshToken = refreshToken;
            Role = new RoleModel { Id = user.Role.Id, Title = user.Role.Title };
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
        public RoleModel Role { get; set; }
    }
}