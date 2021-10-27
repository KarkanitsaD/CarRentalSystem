using System;
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
            Token = token;
            RefreshToken = refreshToken;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}