namespace WebApiApp.Models;

public class Stock{
    public int Id { get; set; }
    public string Symbol { get; set;} = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<Comment>? Comments { get; set; } //Many to one // one stock can have many comments


}