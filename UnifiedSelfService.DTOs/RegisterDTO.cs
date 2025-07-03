using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shared.Domain.Models;

public class RegisterDTO
{
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRoles? UserType { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string? ConfirmPassword { get; set; }
}