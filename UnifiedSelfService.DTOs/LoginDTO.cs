using Shared.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DTOs;

public class LoginDTO 
{
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}