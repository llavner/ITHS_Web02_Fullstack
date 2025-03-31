using Core.DTOs;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class ProductExtension
{
    public static CartItemDTO ToCartItemDTO(this ProductDTO productDTO)
    {
        return new CartItemDTO
        {
            ProductId = productDTO.Id,
            PictureUrl = productDTO.PictureUrl,
            Artist = productDTO.Artist,
            AlbumTitle = productDTO.AlbumTitle,
            Price = productDTO.Price,
            Quantity = productDTO.StockQuantity 
        };
    }

    public static ProductDTO ToProductDTO(this Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            PictureUrl = product.PictureUrl,
            Artist = product.Artist,
            AlbumTitle = product.AlbumTitle,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            IsProductAvailable = product.IsProductAvailable,
            CategoryId = product.CategoryId,
            Category = product.Category

        };
    }

    public static Product ToProduct(this ProductDTO productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            PictureUrl = productDto.PictureUrl,
            Artist = productDto.Artist,
            AlbumTitle = productDto.AlbumTitle,
            Price = productDto.Price,
            StockQuantity = productDto.StockQuantity,
            IsProductAvailable = productDto.IsProductAvailable,
            CategoryId = productDto.CategoryId,
            Category = productDto.Category
        };
    }
}

