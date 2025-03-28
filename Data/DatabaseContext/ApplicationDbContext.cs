using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Data.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //modelBuilder.Entity<Category>().HasData(
        //    new Category { Id = 1, Name = "CD" },
        //    new Category { Id = 2, Name = "Vinyl" }
        //    new Category { Id = 3, Name = "Casette" }
        //);

        //modelBuilder.Entity<Product>().HasData(
        //    new Product { Id = 1, Artist = "Iron Maiden", AlbumTitle = "Live after death", Price = 99, StockQuantity = 10, IsProductAvailable = true, CategoryId = 1 },
        //    new Product { Id = 2, Artist = "Judas Priest", AlbumTitle = "Rocka Rolla", Price = 199, StockQuantity = 10, IsProductAvailable = true, CategoryId = 2 },    
        //    new Product { Id = 3, Artist = "Venom", AlbumTitle = "Black Metal", Price = 69, StockQuantity = 10, IsProductAvailable = true, CategoryId = 3 },
        //);
    }
}

