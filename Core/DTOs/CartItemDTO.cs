using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class CartItemDTO
{
    public int ProductId { get; set; }
    public required string PictureUrl { get; set; }
    public required string Artist { get; set; }
    public required string AlbumTitle { get; set; }
    public long Price { get; set; }
    public int Quantity { get; set; }

}

