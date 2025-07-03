using Shared.Domain.Models;

namespace DTOs;

public class LoginResponseDTOJWT
{
    public bool Status { get; set; } = false;

    public string? Message { get; set; }

    public string? Token { get; set; }

    public UserRoles? UserType { get; set; }

}