using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRACTICE.Context;
using PRACTICE.Dto_s.Stock;
using PRACTICE.Helpers;
using PRACTICE.Interfaces;
using PRACTICE.Mapper;
using PRACTICE.Models;

namespace PRACTICE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IRepository _stockRepo;
 
        public StockController(IRepository stockRepo) {
            _stockRepo = stockRepo;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]StockQueryObject query)
        {
            var Stocks = await _stockRepo.GetAllAsync(query);
            var StocksDTO = Stocks.Select(stock => stock.ToStockDTO());
            return Ok(StocksDTO);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            var stock = await _stockRepo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock(CreateStockDTO stockDto)
        {
            Stock stock = stockDto.ToStock();
            await _stockRepo.CreateAsync(stock);
            return CreatedAtAction(nameof(GetById), new {id = stock.Id }, stockDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute]int id, UpdateStockDTO stockDto)
        {
            var stockFinded = await _stockRepo.UpdateAsync(id, stockDto);
            if (stockFinded == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            var stock = await _stockRepo.DeleteAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
