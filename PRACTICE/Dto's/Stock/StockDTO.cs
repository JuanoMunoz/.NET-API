using PRACTICE.Models;

namespace PRACTICE.Dto_s
{
    public class StockDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CompanyName { get; set; }
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }

        public required string Industry { get; set; }

        public List<CommentDTO> Comments { get; set; }
    }
}
