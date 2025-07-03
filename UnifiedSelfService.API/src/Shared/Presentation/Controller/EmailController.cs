using Shared.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Application;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using DTOs;

[ApiController]
[Route("auth/email")]
public class EmailController : Controller
{
    private readonly IAuthService _authService;
    private readonly UserManager<User> _userManager;

    public EmailController(UserManager<User> userManager, IAuthService authService)
    {
        _userManager = userManager;
        _authService = authService;
    }

    
    [HttpGet("/confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        Console.WriteLine($"userid {userId} {token}");

        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
        {
            return BadRequest(new { Status = false, Message = "Invalid email confirmation request" });
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound(new { Status = false, Message = "User not found" });
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return Ok(new { Status = true, Message = "Email confirmed successfully! You can now log in." });
        }
        else 
        {
            return BadRequest(new { Status = false, Message = "Email confirmation failed", Errors = result.Errors.Select(e => e.Description) });
        }
    }
}


