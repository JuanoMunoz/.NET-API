using Microsoft.EntityFrameworkCore;
using PRACTICE.Context;
using PRACTICE.Dto_s.Stock;
using PRACTICE.Helpers;
using PRACTICE.Interfaces;
using PRACTICE.Models;

namespace PRACTICE.Repository
{
    public class StockRepository : IRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context) {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync(StockQueryObject query)
        {

            var stocks = _context.Stocks.Include(c=>c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Industry))
            {
                stocks = stocks.Where(s=>s.Industry.ToLower().Contains(query.Industry.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
              stocks = stocks.Where(s=>s.CompanyName.ToLower().Contains(query.CompanyName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.ToLower().Equals("companyname"))
                {
                    stocks = query.IsDescending ? stocks.OrderByDescending(s=>s.CompanyName) : stocks.OrderBy(s=>s.CompanyName);
                }
            }
            if(query.Page < 1)
            {
                query.Page = 1;
            }
            var skipsAmmount =(query.Page -1) * query.PageSize;
            return await stocks.Skip(skipsAmmount).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s=>s.Comments).FirstOrDefaultAsync(s=>s.Id == id);
        }

        public async Task<bool> StockExistsAsync(int id)
        {
            return await _context.Stocks.AnyAsync(s=>s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockDTO stockDTO)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if(stock == null)
            {
                return null;
            }
            stock.Name = stockDTO.Name;
            stock.CompanyName = stockDTO.CompanyName;
            stock.Purchase = stockDTO.Purchase;
            stock.LastDiv = stockDTO.LastDiv;
            stock.Industry = stockDTO.Industry;

            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
