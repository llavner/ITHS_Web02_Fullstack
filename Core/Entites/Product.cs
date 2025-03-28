using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites;

public class Product
{
    public int Id { get; set; }
    public string Artist { get; set; }
    public string AlbumTitle { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsProductAvailable { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}


