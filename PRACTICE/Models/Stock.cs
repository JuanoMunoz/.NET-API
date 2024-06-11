using System.ComponentModel.DataAnnotations.Schema;

namespace PRACTICE.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string CompanyName { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal LastDiv { get; set; }

        public required string Industry { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();


          
    }
}
