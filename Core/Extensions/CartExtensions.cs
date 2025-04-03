using Core.DTOs;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class CartExtensions
{
    public static Order ToOrder(this CartDTO cart, int defaultUserId)
    {
        var order = new Order
        {
          
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

