using Microsoft.AspNetCore.Mvc;
using PRACTICE.Dto_s.Stock;
using PRACTICE.Helpers;
using PRACTICE.Models;

namespace PRACTICE.Interfaces
{
    public interface IRepository
    {
        public Task<List<Stock>> GetAllAsync(StockQueryObject query);
        public Task<Stock?> GetByIdAsync(int id);

        public Task<Stock> CreateAsync(Stock stockModel);

        public Task<Stock?> UpdateAsync(int id, UpdateStockDTO stockDTO);

        public Task<Stock?> DeleteAsync(int id);

        public Task<Boolean> StockExistsAsync(int id);

    }
}
