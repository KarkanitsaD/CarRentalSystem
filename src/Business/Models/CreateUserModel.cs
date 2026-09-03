namespace Business.Models
{
    public class CreateUserModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public RoleModel Role { get; set; }
    }
}