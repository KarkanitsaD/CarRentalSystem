using System;

namespace API.Models.Request.User
{
    public class UpdateUserRequest : UserRequest
    {
        public Guid Id { get; set; }
    }
}