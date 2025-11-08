using ASPCourceEmpty.Models;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class PostcardDBContext : IdentityDbContext
{
    // public PostcardDBContext(DbContextOptions<PostcardDBContext> options) : base(options)
    // {

    // }

    private readonly IConfiguration _configuration;

    public PostcardDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _configuration["ConnectionStrings:PostcardsDBCon"];
        optionsBuilder.UseNpgsql(connectionString);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Postcard> Postcards { get; set; }
    public DbSet<ShoppingCartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}