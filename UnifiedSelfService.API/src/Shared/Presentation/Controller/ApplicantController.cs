using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTOs;
using Shared.Domain.Models;
using AutoMapper;

using Shared.Application;

namespace Shared.Presentation;

[ApiController]
[Route("api/[controller]")]
// [Authorize(Roles = "Applicant, Developer")]
public class ApplicantService : ControllerBase
{
    private readonly IApplicantService _applicantService;
    private readonly IMapper _mapper;

    public ApplicantService(IApplicantService applicantService, IMapper mapper)
    {
        _applicantService = applicantService;
        _mapper = mapper;
    }

    [HttpPost("/applicant/request/{userId}/{departmentRequestTypeId}")]
    public async Task<IActionResult> CreateApplicantRequestLetter(Guid userId, Guid departmentRequestTypeId, [FromBody] RequestTransactionDTO requestTransactionDTO)
    {
        try
        {
            if (requestTransactionDTO == null)
            {
                return BadRequest(new { Message = "Input cannot be empty." });
            }

            var requestTransaction = _mapper.Map<RequestTransaction>(requestTransactionDTO);
            var response = await _applicantService.CreateApplicantRequest(userId, departmentRequestTypeId, requestTransaction);

            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }


    [HttpGet("/applicant/allRequests/{userId}/{departmentRequestTypeId}")]
    public async Task<IActionResult> GetAllApplicantRequest(Guid userId, Guid departmentRequestTypeId)
    {
        try
        {
            var result = await _applicantService.GetAllApplicantRequest(userId, departmentRequestTypeId);

            if (!result.Status)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }

    [HttpGet("/applicant/request/{requestId}")]
    public async Task<IActionResult> GetApplicantRequestById(Guid requestId)
    {
        try
        {
            var result = await _applicantService.GetApplicantRequestById(requestId);

            if (!result.Status)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }

    [HttpGet("/applicant/allTransactions/{userId}/{requestId}")]
    public async Task<IActionResult> GetApplicantRequestTransaction(Guid userId, Guid requestId)
    {
        try
        {
            var result = await _applicantService.GetApplicantRequestTransaction(userId, requestId);

            if (!result.Status)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }

    [HttpDelete("/applicantRequest/{userId}/{departmentRequestTypeId}")]
    public async Task<IActionResult> DeleteApplicantRequestLetter(Guid userId, Guid departmentRequestTypeId)
    {
        try
        {
            var result = await _applicantService.DeleteApplicantRequest(userId, departmentRequestTypeId);

            if (!result.Status)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }

    [HttpGet("/applicant/profile/programmesRead/{userId}")]
    public async Task<IActionResult> GetApplicantProgrammesRead(Guid userId)
    {
        try
        {
            var result = await _applicantService.GetApplicantProgrammesRead(userId);

            if (!result.Status)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }


    [HttpGet("/applicant/profile/identification/{userId}")]
    public async Task<IActionResult> GetApplicantIdentification(Guid userId)
    {
        try
        {
            var result = await _applicantService.GetApplicantIdentification(userId);

            if (!result.Status)
            {
                return BadRequest( new {result.Message });
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
        }
    }
    
}
