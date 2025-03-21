using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Data.DatabaseContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        //modelBuilder.Entity<Category>().HasData(
        //    new Category { Id = 1, Name = "CD" },
        //    new Category { Id = 2, Name = "Vinyl" }
        //);

        //modelBuilder.Entity<Product>().HasData(
        //    new Product { Id = 1, Name = "Iron Maiden", Price = 199, StockQuantity = 10, IsProductAvailable = true, CategoryId = 1 },
        //    new Product { Id = 2, Name = "Iron Maiden", Price = 99, StockQuantity = 20, IsProductAvailable = true, CategoryId = 1 },
        //    new Product { Id = 3, Name = "Iron Maiden", Price = 299, StockQuantity = 50, IsProductAvailable = true, CategoryId = 2 }
        //);
    }
}

