using API.Models.Request.Role;

namespace API.Models.Request.User
{
    public class UserRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RoleRequest Role { get; set; }
    }
}