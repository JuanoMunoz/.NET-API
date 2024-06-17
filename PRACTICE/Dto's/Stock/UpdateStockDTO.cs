namespace PRACTICE.Dto_s.Stock
{
    public class UpdateStockDTO
    {
        public required string Name { get; set; }
        public required string CompanyName { get; set; }
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }

        public required string Industry { get; set; }
    }
}
