using Core.DTOs;
using Core.Entites;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Core.Extensions;

namespace Core.Services;

public class ProductService(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7120/api/Product");

        return products.Select(p => p.ToProductDTO()); // Flytta till Controllern?

    }

    public async Task<IEnumerable<ProductDTO>> GetCDAsync()
    {
        var products = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7120/api/Product");

        return products.Where(c => c.Category.Name == "CD").Select(p => p.ToProductDTO());

    }
    public async Task<IEnumerable<ProductDTO>> GetVinylAsync()
    {
        var products = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7120/api/Product");

        return products.Where(c => c.Category.Name == "Vinyl").Select(p => p.ToProductDTO());

    }
    public async Task<IEnumerable<ProductDTO>> GetCasetteAsync()
    {
        var products = await _http.GetFromJsonAsync<List<Product>>("https://localhost:7120/api/Product");

        return products.Where(c => c.Category.Name == "Casette").Select(p => p.ToProductDTO());

    }

    public async Task<ProductDTO> PostAsync(ProductDTO productDto)
    {
        

        var response = await _http.PostAsJsonAsync("https://localhost:7120/api/Product", productDto);

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

