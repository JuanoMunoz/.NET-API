namespace PRACTICE.Dto_s
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
