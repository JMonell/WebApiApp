using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp.Data;
using WebApiApp.DTO;

namespace WebApiApp.Controllers;

[Route("[controller]")]
[ApiController]
public class CommentController : ControllerBase{
    private readonly AppDbContext _dbContext;
    
    public CommentController(AppDbContext dbContext){
        _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetComment(){
        // var comments = _dbContext.Comments.ToListAsync();
        var CommentList = await _dbContext.Comments.ToListAsync();
        return Ok(CommentList);
    }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById([FromRoute] int id){
        
    //     var comment = _dbContext.Comments
    //     .FirstOrDefaultAsync(c => c.Id == id);

    //     if(comment is null){
    //         return NotFound();
    //     }
    //     return Ok(CommentDTO.FromModel(comment));
    // }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromQuery] int stockId){
        
        var comment = _dbContext.Comments
        .Where(c => c.Id == stockId)
        .FirstOrDefault();

        if(comment is null){
            return NotFound();
        }
        return Ok(CommentDTO.FromModel(comment));
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentDTO commentDTO){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        var comment = commentDTO.ToModel();
        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = comment.Id}, CommentDTO.FromModel(comment));
    }

}