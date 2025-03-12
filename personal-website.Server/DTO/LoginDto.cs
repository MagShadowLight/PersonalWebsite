using System.ComponentModel.DataAnnotations;

namespace personal_website.Server.DTO
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool StaySignedIn { get; set; }
    }
}
