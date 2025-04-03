using Core.Entites;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs;

public class CartDTO
{
    public int Id { get; set; }
    public ICollection<CartItemDTO> CartItems { get; set; } = [];
    public void AddItem(ProductDTO item, IEnumerable<ProductDTO> products)
    {
        var product = products.FirstOrDefault(i => i.Id == item.Id) ?? throw new ArgumentException("Item not found");
        
        var existingItem = CartItems.FirstOrDefault(i => i.ProductId == item.Id);
        if (existingItem is not null)
        {
            existingItem.Quantity += 1;
        }
        else
        {
            var newItem = product.ToCartItemDTO();
            newItem.Quantity = 1;
            CartItems.Add(newItem);
        }
    }

    public void RemoveItem(ProductDTO item, IEnumerable<ProductDTO> products)
    {
        

        
    }

}

