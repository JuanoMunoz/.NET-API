
using System.ComponentModel.DataAnnotations;

namespace PRACTICE.Dto_s.Account
{
    public class NewUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]  
        public string Token { get; set; }
    }
}
