using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Shared.Application;

namespace Shared.Presentation;

[ApiController]
[Route("api/[controller]")]

public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    private readonly IMapper _mapper;
    private readonly ILogger<AdminController> _logger;

    public AdminController(IAdminService adminService, IMapper mapper, ILogger<AdminController> logger)
    {
        _adminService = adminService;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet("/allApplicantRequests/{departmentRequestTypeId}")]
    public async Task<IActionResult> GetAllApplicantRequestLetters(Guid departmentRequestTypeId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            if (pageNumber <= 0) pageNumber = 1;  
            if (pageSize <= 0) pageSize = 10; 

            var response = await _adminService.GetAllApplicantRequests(pageNumber, pageSize, departmentRequestTypeId);
            if (!response.Status)
            {
                _logger.LogWarning("Department request type not found at {Time}", DateTime.UtcNow);
                return BadRequest(response.Message);
            }

            _logger.LogInformation("All applicant request letters found at {Time}", DateTime.UtcNow);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching applicant request letters at {Time}", DateTime.UtcNow);
            return StatusCode(500, new { Message = "An unexpected error occurred. Please try again later." });
        }
    }

     [HttpPost("/applicant/verify-requestTransaction/{requestTransactionId}")]
    public async Task<IActionResult> VerifyApplicantRequest(Guid requestTransactionId)
    {
        try
        {
            if (string.IsNullOrEmpty(requestTransactionId.ToString()))
            {
                return BadRequest(new { Message = "Request TransactionId cannot be empty." });
            }

            var response = await _adminService.VerifyApplicantRequest(requestTransactionId);

            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            // Log exception (optional)
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }
}
