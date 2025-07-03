using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Shared.Application;
using Shared.Domain.Models;
using Mappings.SharedMappings;
using DTOs;

namespace Shared.Presentation
{
    [ApiController]
    // [Authorize(AuthenticationSchemes = "MyCookieScheme")]

    [Route("api/[controller]")]
    // [Authorize(Roles = "Developer, DepartmentAdmin, Applicant")]
    public class DeveloperSettingsController : ControllerBase
    {
        private readonly IDeveloperSettingsService _developerSettingsService;
        private readonly IMapper _mapper;

        public DeveloperSettingsController(IDeveloperSettingsService developerSettingsService, IMapper mapper)
        {
            _developerSettingsService = developerSettingsService;
            _mapper = mapper;
        }

        [HttpGet("/request_type")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var result = await _developerSettingsService.GetAllRequestTypes();

                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/requestType/{requestTypeId}")]
        public async Task<IActionResult> GetRequestTypeById(Guid requestTypeId)
        {
            try
            {
                var result = await _developerSettingsService.GetRequestTypeById(requestTypeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/departmentRequestTypeByName/{departmentRequestTypeName}")]
        public async Task<IActionResult> DepartmentRequestTypeByName(string departmentRequestTypeName)
        {
            try
            {
                var result = await _developerSettingsService.GetDepartmentRequestTypeByName(departmentRequestTypeName);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }


        [HttpDelete("/request-type/delete/{requestTypeId}")]
        public async Task<IActionResult> DeleteRequestType(Guid requestTypeId)
        {
            try
            {
                var result = await _developerSettingsService.DeleteRequestType(requestTypeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }


        [HttpGet("/departmentRequestTypesById/{departmentRequestTypeId}")]
        public async Task<IActionResult> DepartmentRequestTypesById(int departmentId)
        {
            try
            {
                var result = await _developerSettingsService.GetAllDepartmentRequestTypesByDepartmentId(departmentId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/singleDepartmentRequestTypeById/{departmentRequestTypeId}")]
        public async Task<IActionResult> GetDepartmentRequestTypeById(Guid departmentRequestTypeId)
        {
            try
            {
                var result = await _developerSettingsService.GetDepartmentRequestTypeById(departmentRequestTypeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/allDepartmentRequestTypes")]
        public async Task<IActionResult> AllDepartmentRequestTypes()
        {
            try
            {
                var result = await _developerSettingsService.GetAllDepartmentRequestTypes();
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/all-request-transactions")]
        public async Task<IActionResult> GetAllRequestTransactions()
        {
            try
            {
                var result = await _developerSettingsService.GetAllRequestTransactions();
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpPost("/request_type")]
        public async Task<IActionResult> CreateRequestType([FromBody] RequestTypeDTO requestTypeDTO)
        {
            try
            {
                var mappedRequest = _mapper.Map<RequestType>(requestTypeDTO);
                var result = await _developerSettingsService.CreateRequestType(mappedRequest);

                if (result.Status)
                {
                    return Created("", new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpPost("/delivery_mode")]
        public async Task<IActionResult> CreateDeliveryMode([FromBody] DeliveryModeDTO deliveryModeDTO)
        {
            try
            {
                var mappedDeliveryMode = _mapper.Map<DeliveryMode>(deliveryModeDTO);
                var result = await _developerSettingsService.CreateDeliveryMode(mappedDeliveryMode);
                if (result.Status)
                {
                    return Created("", new { Message = result.Message, result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/allSubscribedDepartments")]
        public async Task<IActionResult> AllSubscribedDepartment()
        {
            try
            {
                var result = await _developerSettingsService.GetAllSubscribedDepartments();
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpGet("/getSubscribedDepartment/{subscribedDepartmentId}")]
        public async Task<IActionResult> AllSubscribedDepartment(int departmentId)
        {
            var result = await _developerSettingsService.GetSubscribedDepartmentById(departmentId);
            if (result.Status)
            {
                return Created("", new { Message = result.Message, DataObject = result.DataObject });
            }

            return BadRequest(new { Message = result.Message });
        }

        [HttpGet("/allDepartmentRequestTypesByDepartmentId/{departmentId}")]
        public async Task<IActionResult> AllDepartmentRequestTypeById(int departmentId)
        {
            try
            {
                var result = await _developerSettingsService.GetAllDepartmentRequestTypesByDepartmentId(departmentId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }

        [HttpPost("/department_subscription")]
        public async Task<IActionResult> CreateDepartmentSubscription([FromBody] DepartmentSubscriptionRequestDTO departmentSubscriptionRequest)
        {
            try
            {
                var mappedsubscribedDepartment = _mapper.Map<Department>(departmentSubscriptionRequest.DepartmentDTO);
                var result = await _developerSettingsService.CreateSubscribedDepartment(mappedsubscribedDepartment, departmentSubscriptionRequest.generateCredential, departmentSubscriptionRequest.adminEmail);
                Console.WriteLine($"is success: {result.Status}");
                if (result.Status)
                {
                    return Created("", new { Status = result.Status, Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Status = result.Status, Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Status = false, Message = "An error occurred while processing your request.", Details = ex.Message });

            }
        }

        [HttpPost("/createDepartmentRequestType")]
        public async Task<IActionResult> CreateDepartmentRequestType(DepartmentSubscriptionDTO departmentSubscriptionDTO)
        {
            try
            {
                var result = await _developerSettingsService.CreateDepartmentRequestType(departmentSubscriptionDTO);
                if (result.Status)
                {
                    return Created("", new { Message = result.Message, result.DataObject });
                }

                Console.WriteLine("error form here:");
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }



    } 
}
