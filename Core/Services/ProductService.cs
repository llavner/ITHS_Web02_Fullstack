using Core.DTOs;
using Core.Entites;
using System.Net.Http.Json;

namespace Core.Services;

public class ProductService(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7120/api/Product");

        return products.Select(p => new ProductDTO
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            IsProductAvailable = p.IsProductAvailable,
            CategoryId = p.CategoryId,
            Category = p.Category
        });

        //return await _http.GetFromJsonAsync<List<ProductDTO>>("/api/Product");
    }

}

