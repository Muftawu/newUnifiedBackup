using Shared.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Application;
using Microsoft.AspNetCore.Identity;

using DTOs;


[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<User> _userManager;

    public AuthController(UserManager<User> userManager, IAuthService authService)
    {
        _userManager = userManager;
        _authService = authService;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        var response = await _authService.Register(registerDTO);

        if (response is { Status: false })
        {
            return BadRequest(response.Message); 
        }

        return Ok(new { Status = response.Status , response.Message } );
    }

 [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {        
        var response = await _authService.Login(loginDTO);
        if (response.Status)
        {
            return Ok( new { 
                Status = response.Status,
                Message = response.Message, 
                Token = response.Token,
                UserType = response.UserType,
                }); 
        }
        return BadRequest(new { Status = response.Status, Message = response.Message} );
    }


    [HttpGet("/getUserById/{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {        
        var response = await _authService.GetUserById(userId);
        if (response.Status)
        {
            return Ok( new { 
                Message = response.Message, 
                DataObject = response.DataObject,
                }); 
        }
        return BadRequest(new { Message = response.Message} );
    }

    [HttpPost("/updateUser/{userId}")]
    public async Task<IActionResult> UpdateUser(Guid userId, UserDTO userDTO)
    {        
        var response = await _authService.UpdateUser(userId, userDTO);
        if (response.Status)
        {
            return Ok( new { 
                Message = response.Message, 
                // DataObject = response.DataObject,
                }); 
        }
        return BadRequest(new { Message = response.Message} );
    }

    [HttpPost("/createUserProfile")]
    public async Task<IActionResult> CreateUserProfile(CreateUserProfileDTO createUserProfileDTO)
    {       
        var response = await _authService.CreateUserProfile(createUserProfileDTO);
        if (response.Status)
        {
            return Ok( new { 
                Status = response.Status,
                Message = response.Message, 
                }); 
        }
        return BadRequest(new { Status = response.Status, Message = response.Message} );
    }




}
