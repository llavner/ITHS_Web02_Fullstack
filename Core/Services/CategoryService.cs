using Core.DTOs;
using Core.Entites;
using System.Net.Http.Json;

namespace Core.Services;

public class CategoryService(HttpClient http)
{
    private readonly HttpClient _http = http;


    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        var categories = await _http.GetFromJsonAsync<List<Category>>("https://localhost:7120/api/Category");

        return categories.Select(p => new CategoryDTO
        {
            Id = p.Id,
            Name = p.Name
            
        });
    }
    public async Task<CategoryDTO> AddCategoryAsync(CategoryDTO category)
    {
        var response = await _http.PostAsJsonAsync("https://localhost:7120/api/Category", category);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CategoryDTO>();
    }

    public async Task<CategoryDTO> UpdateCategoryAsync(int categoryId, CategoryDTO updatedCategory)
    {
        var response = await _http.PutAsJsonAsync($"https://localhost:7120/api/Category/{categoryId}", updatedCategory);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CategoryDTO>();
    }
    public async Task<CategoryDTO> DeleteAsync(int categoryId)
    {
        var response = await _http.DeleteAsync($"https://localhost:7120/api/Category/{categoryId}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CategoryDTO>();
    }
}

