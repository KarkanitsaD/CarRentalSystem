namespace API.Models.Request.User
{
    public class CreateUserRequest : UserRequest
    {
        public string Password { get; set; }
    }
}