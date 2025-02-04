using Microsoft.EntityFrameworkCore;
using WebApiApp.Models;
namespace WebApiApp.Data;

public class AppDbContext : DbContext{

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public AppDbContext(DbContextOptions options) : base(options){}
    // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


    // protected override void OnModelCreating(ModelBuilder modelBuilder){
    //     // base.OnModelCreating(modelBuilder);

    //     // modelBuilder.Entity<UserModel>()
    //     // .HasMany(u => u.BlogPosts)
    //     // .WithOne(b => b.Author)
    //     // .HasForeignKey(b => b.AuthorID);
        
    // }
}