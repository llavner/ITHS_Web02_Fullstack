using Core.DTOs;
using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class UserExtensions
{
    public static User ToUser(this UserDTO userDto)
    {
        return new User
        {
            Id = userDto.Id,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Address = userDto.Address,
            PhoneNumber = userDto.PhoneNumber,
            IsAdmin = userDto.IsAdmin
        };
    }
}

