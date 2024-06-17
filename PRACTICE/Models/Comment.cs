using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRACTICE.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        [ForeignKey(nameof(StockId))]
        public Stock? Stock { get; set; }
    }
}
