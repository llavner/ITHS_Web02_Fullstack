using Core.DTOs;
using Core.Entites;
using Core.Extensions;
using System.Net.Http.Json;

namespace Core.Services;

public class UserService(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<IEnumerable<UserDTO>> GetAllAsync()
    {
        var user = await _http.GetFromJsonAsync<List<User>>("https://localhost:7120/api/User");


        return user.Select(u => new UserDTO
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Address = u.Address,
            PhoneNumber = u.PhoneNumber,
            IsAdmin = u.IsAdmin
            
        });
    }

    public async Task<UserDTO> PostAsync(UserDTO userDto)
    {
        var user = userDto.ToUser();
        var response = await _http.PostAsJsonAsync("https://localhost:7120/api/User", user);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserDTO>();
    }
    public async Task<UserDTO> UpdateProductAsync(int userId, UserDTO updatedUserDto)
    {
        var updatedUser = updatedUserDto.ToUser();
        var response = await _http.PutAsJsonAsync($"https://localhost:7120/api/User/{userId}", updatedUser);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserDTO>();
    }
    public async Task<UserDTO> DeleteAsync(int userId)
    {
        var response = await _http.DeleteAsync($"https://localhost:7120/api/User/{userId}");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UserDTO>();
    }


}

