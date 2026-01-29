using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.DTOs;

public record UserResponse(
    Guid UserId, 
    string? Email, 
    string? PersonName, 
    string? Gender)
{
    public UserResponse() : this(default, default, default, default)
    { }
};