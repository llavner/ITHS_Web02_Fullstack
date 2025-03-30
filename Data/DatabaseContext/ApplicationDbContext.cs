using Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

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


//        INSERT INTO albums(id, image, artist, album, price, stock, available, rating) VALUES
//(28, 'Beastie-Boys-License-To-Ill.webp', 'Beastie Boys', 'License to Ill', 159, 50, TRUE, 25),
//(29, 'Beatles-Abbey-Road.webp', 'Beatles', 'Abbey Road', 159, 50, TRUE, 25),
//(30, 'Bjork-Homogenic.webp', 'Björk', 'Homogenic', 169, 50, TRUE, 25),
//(31, 'Black-Sabbath-Black-Sabbath.webp', 'Black Sabbath', 'Black Sabbath', 299, 30, TRUE, 26),
//(32, 'David-Bowie-Diamond-Dogs.webp', 'David Bowie', 'Diamond Dogs', 329, 30, TRUE, 26),
//(33, 'grace-jones-nightclubbing.webp', 'Grace Jones', 'Nightclubbing', 159, 40, TRUE, 25),
//(34, 'Janet-Jackson-The-Velvet-Rope.webp', 'Janet Jackson', 'The Velvet Rope', 249, 20, TRUE, 26);
    }
}

