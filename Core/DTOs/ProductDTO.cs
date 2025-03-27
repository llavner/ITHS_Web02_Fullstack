using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    public string Name { get; set; }
    [Required]
    [Range(1, 50000, ErrorMessage = "Please enter a number between 1 and 50000")]
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsProductAvailable { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}



