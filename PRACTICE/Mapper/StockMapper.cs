using PRACTICE.Dto_s;
using PRACTICE.Dto_s.Stock;
using PRACTICE.Models;

namespace PRACTICE.Mapper
{
    public static class StockMapper
    {

        public static StockDTO ToStockDTO(this Stock stock)
        {
            return new StockDTO
            {
                Id = stock.Id,
                Name = stock.Name,
                CompanyName = stock.CompanyName,
                Industry = stock.Industry,
                LastDiv = stock.LastDiv,
                Purchase = stock.Purchase,
                Comments = stock.Comments.Select(c=>c.ToCommentDTO()).ToList(),
            };

        }
        public static Stock ToStock(this CreateStockDTO stockDTO)
        {
            return new Stock
            {
                Name = stockDTO.Name,
                CompanyName = stockDTO.CompanyName,
                Industry = stockDTO.Industry,
                LastDiv = stockDTO.LastDiv,
                Purchase = stockDTO.Purchase

            };
        }

    }
}
