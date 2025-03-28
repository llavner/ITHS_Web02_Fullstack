using Core.DTOs;
using Core.Entites;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Core.Services;

public class ProductService(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7120/api/Product");


        return products.Select(p => new ProductDTO
        {
            Id = p.Id,
            Artist = p.Artist,
            AlbumTitle = p.AlbumTitle,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            IsProductAvailable = p.IsProductAvailable,
            CategoryId = p.CategoryId,
            Category = p.Category
        });
    }

    public async Task<ProductDTO> PostAsync(ProductDTO product)
    {
        var response = await _http.PostAsJsonAsync("https://localhost:7120/api/Product", product);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ProductDTO>();
    }
    public async Task<ProductDTO> UpdateProductAsync(int productId, ProductDTO updatedProduct)
    {
        var response = await _http.PutAsJsonAsync($"https://localhost:7120/api/Product/{productId}", updatedProduct);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ProductDTO>();
    }
    public async Task<ProductDTO> DeleteAsync(int productId)
    {
        var response = await _http.DeleteAsync($"https://localhost:7120/api/Product/{productId}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ProductDTO>();
    }

}

