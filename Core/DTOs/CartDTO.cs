using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class CartDTO
{
    public int Id { get; set; }
    public ICollection<CartItemDTO> CartItems { get; set; }
}

