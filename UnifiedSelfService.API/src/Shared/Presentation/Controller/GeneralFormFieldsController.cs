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
    [Route("api/[controller]")]
    // [Authorize]
    public class GeneralFormFieldsController : ControllerBase
    {
        private readonly IGeneralFormFieldService _generalFormFieldService;
        private readonly IMapper _mapper;

        public GeneralFormFieldsController(IGeneralFormFieldService generalFormFieldService, IMapper mapper)
        {
            _generalFormFieldService = generalFormFieldService;
            _mapper = mapper;
        }



        [HttpGet("/formStep/{requestTypeId}")]
        public async Task<IActionResult> GetAllFormStepsFieldsByServiceId(Guid requestTypeId)
        {
            try
            {
                var result = await _generalFormFieldService.GetGeneralFormStepsWithFields(requestTypeId);
                if (result.Status)
                {
                    return Ok(new { Status = true, Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request.", Details = ex.Message });
            }
        }



        [HttpDelete("/requestTypeFormStep/{formStepId}")]
        public async Task<IActionResult> DeleteFormStepById(Guid formStepId)
        {
            try
            {
                var result = await _generalFormFieldService.DeleteFormStep(formStepId);

                if (result.Status)
                {
                    return Ok(new { Message = result.Message });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting department request type form step" });
            }
        }
        




        [HttpDelete("/requestTypeFormField/{formFieldId}")]
        public async Task<IActionResult> DeleteFormFieldById(Guid formFieldId)
        {
            try
            {
                var result = await _generalFormFieldService.DeleteFormField(formFieldId);
                if (result.Status)
                {
                    return Ok(new { Message = result.Message });
                }
                return BadRequest(new { Message = result.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting department request type form field" });
            }
        }


        [HttpPost("/addFormStep/{serviceId}")]
        public async Task<IActionResult> AddFormStep(Guid serviceId, List<RequestTypeFormStepDTO> formStepDTO)
        {

            try
            {
                var result = await _generalFormFieldService.AddFormSteps(serviceId, formStepDTO);

                if (result.Status)
                {
                    return Created("Create Successfully", new { Message = result.Message, DataObject = result.DataObject });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred processing your request.", Details = ex.Message });
            }

            }
       



        [HttpPost("/serviceFormField/{formStepId}/")]
        public async Task<IActionResult> AddFormFieldWithOptions(
           Guid formStepId,
           [FromBody] FormFieldWithOptionsDTO request)
        {
            try
            {
                var result = await _generalFormFieldService.AddFormFieldWithOptions(
                    formStepId,
                    request.FormField,
                    request.SelectOptions
                );

                if (result.Status)
                {
                    return Created("", new { Message = result.Message });
                }

                return BadRequest(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred processing your request.", Details = ex.Message });
            }
        }



    }
}
