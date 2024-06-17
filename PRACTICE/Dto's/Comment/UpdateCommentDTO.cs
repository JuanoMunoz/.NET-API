using System.ComponentModel.DataAnnotations;

namespace PRACTICE.Dto_s.Comment
{
    public class UpdateCommentDTO
    {
        [Required]
        [MinLength(4, ErrorMessage = "You must provide a title with more than 4 characters.")]
        [MaxLength(255, ErrorMessage = "You must provide a title with less than 255 characters.")]
        public required string Title { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "You must provide a content with more than 4 characters.")]
        [MaxLength(255, ErrorMessage = "You must provide a content with less than 255 characters.")]
        public required string Content { get; set; }
    }
}
