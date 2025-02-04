namespace WebApiApp.Models;

public class Comment{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public Stock? Stock { get; set; }
    public int StockId { get; set; }

    
}