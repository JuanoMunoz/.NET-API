using System.ComponentModel.DataAnnotations;

namespace PRACTICE.Dto_s.Stock
{
    public class CreateStockDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "You must provide a Name with more than 1 character.")]
        [MaxLength(50, ErrorMessage = "You must provide a Name with less than 50 characters.")]
        public required string Name { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "You must provide a Company name with more than 1 character.")]
        [MaxLength(50, ErrorMessage = "You must provide a Company name with less than 50 characters.")]
        public required string CompanyName { get; set; }
        [Required]
        [Range(1,10000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.1, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(100)]

        public required string Industry { get; set; }
        
    }
}
