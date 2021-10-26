using System;
using Data.Entities;

namespace Business.Models
{
    public class AuthenticateResponseModel
    {
        public AuthenticateResponseModel(UserEntity userEntity, string token)
        {
            Id = userEntity.Id;
            Email = userEntity.Email;
            Name = userEntity.Name;
            Token = token;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}