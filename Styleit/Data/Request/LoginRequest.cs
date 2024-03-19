using System.ComponentModel.DataAnnotations;

namespace Styleit.Data.Request
{
    public class LoginRequest
    {
        [Required]
        public string email { get; set; }
        public string password { get; set; }
    }
}
