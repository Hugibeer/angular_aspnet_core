using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.DTO
{
    public class RegisterUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Password must be string from 5 to 255 character length")]
        public string Password { get; set; }        
    }
}