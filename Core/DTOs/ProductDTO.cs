using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsProductAvailable { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}



