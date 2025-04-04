using Core.DTOs;
using Core.Entites;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Core.Services;

public class OrderService(HttpClient http)
{
    private readonly HttpClient _http = http;
    public async Task<IEnumerable<CartDTO>> GetAllAsync()
    {
        var orders = await _http.GetFromJsonAsync<List<Order>>("https://localhost:7120/api/Order");

        return orders.Select(p => p.ToCartDTO());
    }
    public async Task<bool> AddOrderAsync(CartDTO cart, UserDTO user)
    {
        
        var order = cart.ToOrder(user);
        var response = await _http.PostAsJsonAsync("https://localhost:7120/api/Order", order);

        if(response.IsSuccessStatusCode)
        {
            Debug.WriteLine("Order sent");
            return true;
        }
        else
        {
            Debug.WriteLine("Order not placed");
            return false;
            
        }  
    }

    public async Task<CartDTO> UpdateOrderAsync(int orderId, CartDTO updatedCart, UserDTO user)
    {
        var updatedOrder = updatedCart.ToOrder(user);
        var response = await _http.PutAsJsonAsync($"https://localhost:7120/api/Order/{orderId}", updatedOrder);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CartDTO>();
    }
    public async Task<CartDTO> DeleteAsync(int orderId)
    {
        var response = await _http.DeleteAsync($"https://localhost:7120/api/Order/{orderId}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CartDTO>();
    }

}

