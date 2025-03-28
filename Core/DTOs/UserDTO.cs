using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    public string LastName { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; }
    [Required]
    [Range(1,50, ErrorMessage = "Phonenumber cannot be longer than 50 characters")]
    public string PhoneNumber { get; set; }
    public bool IsAdmin { get; set; }
}

