using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
namespace PRACTICE.Dto_s.Account
{
    public class RegisterDTO
    {
        [System.ComponentModel.DataAnnotations.Required]
        public required string Username { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [EmailAddress] 
        public required string Email { get; set;}

        [System.ComponentModel.DataAnnotations.Required] 
        public required string Password { get; set; }
    }
}
