using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRACTICE.Context;
using PRACTICE.Models;

namespace PRACTICE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController :ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Stocks =  _context.Stocks.ToList();
            return Ok(Stocks);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {

            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}
