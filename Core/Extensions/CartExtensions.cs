using Core.DTOs;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class CartExtensions
{
    public static Order ToOrder(this CartDTO cart, UserDTO user)
    {
        var order = new Order
        {
            Id = 1,
            UserId = user.Id,
            OrderDate = DateTime.Now,
            Status = "Pending",
            User = user.ToUser(),
            OrderItems = cart.CartItems.Select(item => new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList()
        };

        return order;
    }

    public static CartDTO ToCartDTO(this Order order)
    {
        return new CartDTO
        {
            

        };
    }
}

