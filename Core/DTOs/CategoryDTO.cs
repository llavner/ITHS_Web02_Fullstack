using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Category name is required.")]
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

