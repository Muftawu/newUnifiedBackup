using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Shared.Application;
using Shared.Domain.Models;
using Mappings.SharedMappings;
using DTOs;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Shared.Presentation
{  
    //  [Authorize(AuthenticationSchemes = "MyCookieScheme")]

    [ApiController]
    [Route("unifiedSelfService/api/[controller]")]
    public class DepartmentSettingsController : ControllerBase
    {
        private readonly IDepartmentSettingsService _departmentSetting;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentSettingsController> _logger;

        public DepartmentSettingsController(IDepartmentSettingsService departmentSetting, IMapper mapper, ILogger<DepartmentSettingsController> logger)
        {
            _departmentSetting = departmentSetting;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("/departmentSettings/profile/{subscribedDepartmentId}")]
        public async Task<IActionResult> CreateDepartmentSettings(int departmentId, [FromBody] DepartmentSettingDTO departmentSettingDTO)
        {
            try
            {
                var mappedDepartmentSetting = _mapper.Map<DepartmentSetting>(departmentSettingDTO);
                var result = await _departmentSetting.CreateDepartmentProfile(departmentId, mappedDepartmentSetting);

                if (result.Status)
                {
                    return Created("", new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating department settings");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("/departmentSettings/profile/{departmentSettingsId}")]
        public async Task<IActionResult> GetDepartmentSettingsbyId(Guid departmentSettingsId)
        {
            try
            {
                var result = await _departmentSetting.GetDepartmentProfileById(departmentSettingsId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching department settings by ID");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("/departmentSettings/profile")]
        public async Task<IActionResult> GetAllDepartmentSettings()
        {
            try
            {
                var result = await _departmentSetting.GetAllDepartmentProfile();
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all department settings");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpPatch("/departmentSettings/profile/{departmentSettingsId}")]
        public async Task<IActionResult> UpdateDepartmentSettings(Guid departmentSettingsId, [FromBody] DepartmentSettingDTO departmentSettingDTO)
        {
            try
            {
                var mappedDepartmentSetting = _mapper.Map<DepartmentSetting>(departmentSettingDTO);
                var result = await _departmentSetting.UpdateDepartmentProfile(departmentSettingsId, mappedDepartmentSetting);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating department settings");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpDelete("/departmentSettings/profile/{departmentSettingsId}")]
        public async Task<IActionResult> DeleteDepartmentSettings(Guid departmentSettingsId)
        {
            try
            {
                var result = await _departmentSetting.DeleteDepartmentProfile(departmentSettingsId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting department settings");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpPost("/departmentDeliveryMode/{requestTypeId}")]
        public async Task<IActionResult> CreateDepartmentDeliveryMode(Guid requestTypeId, [FromBody] DepartmentDeliveryModeDTO departmentDeliveryModeDTO)
        {
            try
            {
                var mappedDepartmentDeliveryMode = _mapper.Map<DepartmentDeliveryMode>(departmentDeliveryModeDTO);
                var result = await _departmentSetting.CreateDepartmentDeliveryModeSettings(requestTypeId, mappedDepartmentDeliveryMode);

                if (result.Status)
                {
                    return Created("", new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating department delivery mode");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("/departmentDeliveryMode")]
        public async Task<IActionResult> GetAllDepartmentDeliveryMode()
        {
            try
            {
                var result = await _departmentSetting.GetAllDepartmentDeliveryModeSettings();
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all department delivery modes");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("/departmentDeliveryMode/{departmentDeliveryModeId}")]
        public async Task<IActionResult> GetDepartmentDeliveryModeById(Guid departmentDeliveryModeId)
        {
            try
            {
                var result = await _departmentSetting.GetDepartmentDeliveryModeSettingsById(departmentDeliveryModeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching department delivery mode by ID");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpPatch("/departmentDeliveryMode/{departmentDeliveryModeId}")]
        public async Task<IActionResult> UpdateDepartmentDeliveryMode(Guid departmentDeliveryModeId, [FromBody] DepartmentDeliveryModeDTO departmentDeliveryModeDTO)
        {
            try
            {
                var mappedDepartmentDeliveryMode = _mapper.Map<DepartmentDeliveryMode>(departmentDeliveryModeDTO);
                var result = await _departmentSetting.UpdateDepartmentDeliveryModeSettings(departmentDeliveryModeId, mappedDepartmentDeliveryMode);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating department delivery mode");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpDelete("/departmentDeliveryMode/{departmentDeliveryModeId}")]
        public async Task<IActionResult> DeleteDepartmentDeliveryMode(Guid departmentDeliveryModeId)
        {
            try
            {
                var result = await _departmentSetting.DeleteDepartmentDeliveryModeSettings(departmentDeliveryModeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting department delivery mode");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }
        
        [HttpPatch("requestedReferee/{requestedRefereeId}")]
        public async Task<IActionResult> UpdateRequestedReferee(Guid requestedRefereeId, [FromBody] RequestedRefereeDTO requestedRefereeDTO)
        {
            try
            {
                var mappedRequestedReferee = _mapper.Map<RequestedReferee>(requestedRefereeDTO);
                var result = await _departmentSetting.UpdateRequestedReferee(requestedRefereeId, mappedRequestedReferee);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating requested referee");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpDelete("requestedReferee/{requestedRefereeId}")]
        public async Task<IActionResult> DeleteRequestedReferee(Guid requestedRefereeId)
        {
            try
            {
                var result = await _departmentSetting.DeleteRequestedReferee(requestedRefereeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting requested referee");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("requestedReferee")]
        public async Task<IActionResult> GetAllRequestedReferee()
        {
            try
            {
                var result = await _departmentSetting.GetAllRequestedReferee();
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all requested referees");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }

        [HttpGet("requestedReferee/{requestedRefereeId}")]
        public async Task<IActionResult> GetRequestedRefereeById(Guid requestedRefereeId)
        {
            try
            {
                var result = await _departmentSetting.GetRequestedRefereeById(requestedRefereeId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message, result.DataObject });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching requested referee by ID");
                return StatusCode(500, new { Message = "An error occurred while processing your request" });
            }
        }
    }
}
