using Microsoft.EntityFrameworkCore;
using Shared.Application;
using System.Threading.Tasks;
using Shared.Domain.Models;
using DTOs;
using Shared.Infrastructure;

public class GeneralFormFieldService : IGeneralFormFieldService
{
    private readonly ApplicationDbContext _applicationDbContext;


    public GeneralFormFieldService(ApplicationDbContext applicationDbContext, IAuthService authService)
    {
        _applicationDbContext = applicationDbContext;

    }



    public async Task<ResponseDTO> GetGeneralFormStepsWithFields(Guid requestTypeId)
    {
        var requestType = await _applicationDbContext.RequestTypes.AnyAsync(x => x.RequestTypeId == requestTypeId);

        Console.WriteLine($"this is the request type: {requestType}");




        if (!requestType)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "The Request not found",


            };
        }

        //Get the list of form steps.
        var formStep = await _applicationDbContext.RequestTypeFormStep.Where(x => x.RequestTypeId == requestTypeId).Include(f => f.FormFields).ThenInclude(o => o.FormSelectOptions).ToListAsync();

        Console.WriteLine($"this is the form steps:  {formStep}");



        if (formStep == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Form Field not found",
                DataObject = formStep
            };
        }
        return new ResponseDTO
        {
            Status = true,
            Message = "Found department request type form fields",
            DataObject = formStep
        };
    }

    public async Task<ResponseDTO> DeleteFormField(Guid FormFieldId)
    {


        var formField = await _applicationDbContext.FormFields
            .FirstOrDefaultAsync(f => f.FormFieldsId == FormFieldId);

        if (formField == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No department request type form field request type found"
            };
        }

        // delete goes here
        _applicationDbContext.FormFields.Remove(formField);
        await _applicationDbContext.SaveChangesAsync();
        return new ResponseDTO
        {
            Status = true,
            Message = "Field successfully deleted",
        };

    }




    public async Task<ResponseDTO> DeleteFormStep(Guid requestTypeFormStepId)
    {


        var formField = await _applicationDbContext.RequestTypeFormStep
            .FirstOrDefaultAsync(s => s.RequestTypeFormStepId == requestTypeFormStepId);

        if (formField == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No department request type form field request type found"
            };
        }

        // delete goes here
        _applicationDbContext.RequestTypeFormStep.Remove(formField);
        await _applicationDbContext.SaveChangesAsync();
        return new ResponseDTO
        {
            Status = true,
            Message = "Field successfully deleted",
        };

    }


    public async Task<ResponseDTO> AddFormSteps(Guid requestTypeId, List<RequestTypeFormStepDTO> formStepDTO)
    {
        var requestTypeExists = await _applicationDbContext.RequestTypes.AnyAsync(x => x.RequestTypeId == requestTypeId);




        if (requestTypeExists && formStepDTO != null && formStepDTO.Count > 0)
        {


            var formSteps = formStepDTO.Select(dto => new RequestTypeFormStep()
            {
                RequestTypeFormStepId = Guid.NewGuid(),
                RequestTypeId = requestTypeId,
                StepNumber = dto.StepNumber,
                StepDescription = dto.StepDescription


            }).ToList();

            await _applicationDbContext.RequestTypeFormStep.AddRangeAsync(formSteps);

            int result = await _applicationDbContext.SaveChangesAsync();

            if (result > 0)
        {
            return new ResponseDTO
            {
                Status = true,
                Message = "Saved Successfully",
                DataObject = formSteps
            };
            
           }
        }

         return new ResponseDTO
            {
                Status = true,
                Message = "Unable to save",
                
            };
        

    }



    public async Task<ResponseDTO> AddFormFieldWithOptions(
           Guid formStepId,
           FormFieldDTO formFieldDto,
           List<FormSelectOptionDTO> selectOptionDtos)
    {
        ArgumentNullException.ThrowIfNull(formFieldDto);

        await using var transaction = await _applicationDbContext.Database.BeginTransactionAsync();

        try
        {


            bool formStepExits = await _applicationDbContext.RequestTypeFormStep.AnyAsync(s => s.RequestTypeFormStepId == formStepId);


            if (!formStepExits)
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Form step does not exist"
                };
            }

            var formField = new FormFields
            {
                FormFieldsId = Guid.NewGuid(),

                Label = formFieldDto.Label,
                InputType = Enum.Parse<InputTypesEnum>(formFieldDto.InputType),
                IsRequired = formFieldDto.IsRequired,
                Placeholder = formFieldDto.Placeholder,
                RequestTypeFormStepId = formStepId
            };

            await _applicationDbContext.FormFields.AddAsync(formField);

            if (selectOptionDtos != null && selectOptionDtos.Count != 0)
            {
                var optionEntities = selectOptionDtos.Select(dto => new FormSelectOptions
                {
                    FormSelectOptionsId = Guid.NewGuid(),
                    FormFieldsId = formField.FormFieldsId,
                    OptionName = dto.OptionName,
                    CreatedDate = dto.CreatedDate,
                    UpdatedDate = dto.UpdatedDate,
                    CreatedBy = dto.CreatedBy,
                    UpdatedBy = dto.UpdatedBy
                }).ToList();

                await _applicationDbContext.FormSelectOptions.AddRangeAsync(optionEntities);

            }

            await _applicationDbContext.SaveChangesAsync();
            await transaction.CommitAsync();


            return new ResponseDTO
            {
                Status = true,
                Message = "Form field and options added successfully"
            };
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();


            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner: {ex.InnerException?.Message}"
            };
        }
    }
}






