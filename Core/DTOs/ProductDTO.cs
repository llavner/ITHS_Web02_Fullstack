using Core.Entites;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string Artist { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string AlbumTitle { get; set; }
    public string PictureUrl { get; set; }
    [Required]
    [Range(1, 50000, ErrorMessage = "Please enter a number between 1 and 50000")]
    public long Price { get; set; }
    [Required]
    [Range(1, 500, ErrorMessage = "Please enter a number between 1 and 500")]
    public int StockQuantity { get; set; }
    public bool IsProductAvailable { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}



