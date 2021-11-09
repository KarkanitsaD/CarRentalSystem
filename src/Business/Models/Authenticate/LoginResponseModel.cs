using System;
using System.Linq;
using Data.Entities;

namespace Business.Models.Authenticate
{
    public class LoginResponseModel
    {
        public LoginResponseModel(UserEntity userEntity, string token, string refreshToken)
        {
            Id = userEntity.Id;
            Email = userEntity.Email;
            Name = userEntity.Name;
            Jwt = token;
            RefreshToken = refreshToken;
            Roles = userEntity.Roles.Select(role => role.Title).ToArray();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
        public string[] Roles { get; set; }
    }
}