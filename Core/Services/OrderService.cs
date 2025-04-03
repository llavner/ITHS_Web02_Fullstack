using Core.DTOs;
using Core.Entites;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Core.Services;

public class OrderService(HttpClient http)
{
    private readonly HttpClient _http = http;
    //public async Task<IEnumerable<CartDTO>> GetAllAsync()
    //{
    //    var orders = await _http.GetFromJsonAsync<List<Order>>("https://localhost:7120/api/Order");

    //    return orders.Select(p => p.);
    //}
    public async Task<bool> AddOrderAsync(CartDTO cart)
    {
        var order = cart.ToOrder(1);
        var response = await _http.PostAsJsonAsync("https://localhost:7120/api/Order", order);

        if(response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }  
    }

    //public async Task<CategoryDTO> UpdateCategoryAsync(int categoryId, CategoryDTO updatedCategory)
    //{
    //    var response = await _http.PutAsJsonAsync($"https://localhost:7120/api/Category/{categoryId}", updatedCategory);
    //    response.EnsureSuccessStatusCode();

    //    return await response.Content.ReadFromJsonAsync<CategoryDTO>();
    //}
    public async Task<CartDTO> DeleteAsync(int orderId)
    {
        var response = await _http.DeleteAsync($"https://localhost:7120/api/Order/{orderId}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CartDTO>();
    }

}

