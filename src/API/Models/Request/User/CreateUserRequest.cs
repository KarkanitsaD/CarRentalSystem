using API.Models.Request.Role;

namespace API.Models.Request.User
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public RoleRequest Role { get; set; }
    }
}