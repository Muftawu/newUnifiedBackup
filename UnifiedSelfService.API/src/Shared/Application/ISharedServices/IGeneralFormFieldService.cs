using DTOs;
using Shared.Domain.Models; 
namespace Shared.Application;


public interface IGeneralFormFieldService
{
    Task<ResponseDTO> AddFormSteps(Guid requestTypeId, List<RequestTypeFormStepDTO> formStepDTO);
    Task<ResponseDTO> AddFormFieldWithOptions(Guid formStepId, FormFieldDTO formFieldDto,
    List<FormSelectOptionDTO> selectOptionDtos);



    Task<ResponseDTO> GetGeneralFormStepsWithFields(Guid requestTypeId);

    Task<ResponseDTO> DeleteFormField(Guid FormFieldId);
    Task<ResponseDTO> DeleteFormStep(Guid requestTypeFormStepId);
}