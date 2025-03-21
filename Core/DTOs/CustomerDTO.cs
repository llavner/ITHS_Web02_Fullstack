﻿using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

