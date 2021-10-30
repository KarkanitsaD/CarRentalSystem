using System.ComponentModel.DataAnnotations;

namespace Business.Models.Authenticate
{
    public class LoginRequestModel
    {   
        [Required]
        [EmailAddress]
        public string  Email{ get; set; }

        [Required]
        public string  Password{ get; set; }
    }
}