using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class UserRegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }

        public string Name { get; set; }
    }
}
