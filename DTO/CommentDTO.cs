using WebApiApp.Models;
namespace WebApiApp.DTO;

public class CommentDTO{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
     public int StockId { get; set; }

    public static CommentDTO FromModel(Comment comment){
        return new CommentDTO{
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedDate = comment.CreatedDate,
            StockId = comment.StockId
        };

    }
    public Comment ToModel(){
        return new Comment{
            Id = Id,
            Title = Title,
            Content = Content,
            CreatedDate = CreatedDate,
            StockId = StockId
        };
    }

}