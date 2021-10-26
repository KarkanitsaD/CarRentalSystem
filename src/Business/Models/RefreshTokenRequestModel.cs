using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class RefreshTokenRequestModel
    {
        [Required]
        public string Token { get; set; }
    }
}
