using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp.Data;
using WebApiApp.DTO;

namespace WebApiApp.Controllers;

[Route("[controller]")]
[ApiController]
public class StockController : ControllerBase{
    private readonly AppDbContext _dbContext;
    
    public StockController(AppDbContext dbContext){
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromQuery] int id, bool include = false){
        var stocks = _dbContext.Stocks.AsQueryable();
        if(!include){
            stocks = stocks.Include(s => s.Comments);
        }
        var result = await stocks.FirstOrDefaultAsync(s => s.Id == id);
        if(result is null){
            return NotFound();
        }
        return Ok(StockDTO.FromModel(result));
    }

    [HttpGet]
    public async Task<IActionResult> GetStocks([FromQuery] bool include = false){
        var stocks = _dbContext.Stocks.AsQueryable();
        if(include){
            stocks = stocks.Include(s => s.Comments);
        }
        var stockList = await stocks.ToListAsync();
        return Ok(stockList);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStock([FromBody] StockDTO stockDTO){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        var stock = stockDTO.ToModel();
        _dbContext.Stocks.Add(stock);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = stock.Id}, StockDTO.FromModel(stock));
    }
}
