using Shared.Application;
using System.Threading.Tasks;
using Shared.Domain.Models;
using DTOs;
using Shared.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace Shared.Infrastructure;

public class DepartmentSettingsService : IDepartmentSettingsService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly ResponseDTO responseDTO = new ResponseDTO();

    public DepartmentSettingsService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ResponseDTO> CreateDepartmentProfile(int departmentId, DepartmentSetting departmentSetting)
    {
        if (departmentSetting == null)
        {

            return responseDTO.SetStatus(false).SetMessage("Department settings cannot be null");
        }


        var subscribedDepartmentExists = await _applicationDbContext.Departments.AsNoTracking().AnyAsync(sd => sd.DepartmentId == departmentId);

        if (!subscribedDepartmentExists)
        {
            return responseDTO.SetStatus(false).SetMessage("The specified SubscribedDepartmentId does not exist.");

        }

        // Set the SubscribedDepartmentId in departmentSetting
        departmentSetting.DeptId = departmentId;

        try
        {
            await _applicationDbContext.DepartmentSettings.AddAsync(departmentSetting);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {

                return responseDTO.SetStatus(true).SetMessage("Department settings made successfully").SetDataObject(departmentSetting);
            }


            return responseDTO.SetStatus(false).SetMessage("Failed to save the department subscription");
        }
        catch (Exception)
        {

            return responseDTO.SetStatus(false).SetMessage($"An unexpected error occurred. Please try again later.");

        }
    }


    public async Task<ResponseDTO> GetDepartmentProfileById(Guid departmentSettingsId)
    {
        var departmentProfile = await _applicationDbContext.DepartmentSettings.AsNoTracking().FirstOrDefaultAsync(ds => ds.DepartmentSettingsId == departmentSettingsId);

        if (departmentProfile == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department settings not found");
        }
        return responseDTO.SetStatus(true).SetMessage("Department settings found").SetDataObject(departmentProfile);
    }


    public async Task<ResponseDTO> GetAllDepartmentProfile()
    {
        var allDepartmentProfile = await _applicationDbContext.DepartmentSettings.AsNoTracking().ToListAsync();

        if (allDepartmentProfile.Any())
        {
            return responseDTO.SetStatus(true).SetMessage("Departments profiles found.").SetDataObject(allDepartmentProfile);
        }

        return responseDTO.SetStatus(false).SetMessage("No department profile found.");
    }


    public async Task<ResponseDTO> UpdateDepartmentProfile(Guid departmentSettingsId, DepartmentSetting departmentSetting)
    {
        var existingDepartmentProfile = await _applicationDbContext.DepartmentSettings.AsNoTracking()
            .AnyAsync(ds => ds.DepartmentSettingsId == departmentSettingsId);

        if (!existingDepartmentProfile)
        {
            return responseDTO.SetStatus(false).SetMessage("Department settings not found");
        }

        var properties = existingDepartmentProfile.GetType().GetProperties();

        foreach (var property in properties)
        {
            var newValue = property.GetValue(departmentSetting);

            if (newValue != null)
            {
                property.SetValue(departmentSetting, newValue);
            }
        }

        await _applicationDbContext.SaveChangesAsync();

        return responseDTO.SetStatus(true).SetMessage("Department profile updated successfully.");

    }

   public async Task<ResponseDTO> DeleteDepartmentProfile(Guid departmentSettingsId)
{
    
    var existingDepartmentProfile = await _applicationDbContext.DepartmentSettings
        .FirstOrDefaultAsync(ds => ds.DepartmentSettingsId == departmentSettingsId);

 
    if (existingDepartmentProfile == null)
    {
        return responseDTO.SetStatus(false).SetMessage("Department settings not found");
    }


    _applicationDbContext.DepartmentSettings.Remove(existingDepartmentProfile);
    await _applicationDbContext.SaveChangesAsync();

    return responseDTO.SetStatus(true).SetMessage("Department settings successfully deleted");
}





    public async Task<ResponseDTO> CreateDepartmentDeliveryModeSettings(Guid requestTypeId, DepartmentDeliveryMode departmentDeliveryMode)
    {
        if (departmentDeliveryMode == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department Delivery mode settings cannot be empty");
        }


        var departmentRequestTypeExits = await _applicationDbContext.DepartmentRequestTypes
            .AnyAsync(dm => dm.RequestTypeId == requestTypeId);


        if (!departmentRequestTypeExits)
        {
            return responseDTO.SetStatus(false).SetMessage("The specified Request Type does not exist.");
        }


        departmentDeliveryMode.DepartmentRequestTypeId = requestTypeId;

        try
        {
            await _applicationDbContext.DepartmentDeliveryModes.AddAsync(departmentDeliveryMode);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                return responseDTO.SetStatus(true).SetMessage("Department Delivery mode settings made successfully").SetDataObject(departmentDeliveryMode);
            }

            return responseDTO.SetStatus(false).SetMessage("Failed to save the department delivery mode settings");
        }
        catch (Exception)
        {
            return responseDTO.SetStatus(false).SetMessage($"An unexpected error occurred. Please try again later.");
        }
    }

    public async Task<ResponseDTO> GetAllDepartmentDeliveryModeSettings()
    {
        var allDepartmentDeliveryModeSettings = await _applicationDbContext.DepartmentDeliveryModes.ToListAsync();
        if (allDepartmentDeliveryModeSettings.Any())
        {
            return responseDTO.SetStatus(true).SetMessage("Department delivery mode settings found.").SetDataObject(allDepartmentDeliveryModeSettings);
        }
        return responseDTO.SetStatus(false).SetMessage("No department delivery mode settings found.");
    }

    public async Task<ResponseDTO> GetDepartmentDeliveryModeSettingsById(Guid departmentDeliveryModeId)
    {
        var departmentDeliveryModeSettings = await _applicationDbContext.DepartmentDeliveryModes
            .FirstOrDefaultAsync(ddm => ddm.DepartmentDeliveryModeId == departmentDeliveryModeId);

        if (departmentDeliveryModeSettings == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department delivery mode settings not found");
        }

        return responseDTO.SetStatus(true).SetMessage("Department delivery mode settings found").SetDataObject(departmentDeliveryModeSettings);
    }

    public async Task<ResponseDTO> UpdateDepartmentDeliveryModeSettings(Guid departmentDeliveryModeId, DepartmentDeliveryMode departmentDeliveryMode)
    {
        var existingDepartmentDeliveryModeSettings = await _applicationDbContext.DepartmentDeliveryModes
             .FirstOrDefaultAsync(ddm => ddm.DepartmentDeliveryModeId == departmentDeliveryModeId);

        if (existingDepartmentDeliveryModeSettings == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department delivery mode settings not found");
        }

        var properties = existingDepartmentDeliveryModeSettings.GetType().GetProperties();
        foreach (var property in properties)
        {
             if (property.PropertyType == typeof(Guid))
        {
            continue;
        }

            var newValue = property.GetValue(departmentDeliveryMode);
            if (newValue != null)
            {
                property.SetValue(existingDepartmentDeliveryModeSettings, newValue);
            }
        }

        await _applicationDbContext.SaveChangesAsync();

        return responseDTO.SetStatus(true).SetMessage("Department delivery mode settings updated successfully.");
    }

    public async Task<ResponseDTO> DeleteDepartmentDeliveryModeSettings(Guid departmentDeliveryModeId)
    {
        var existingDepartmentDeliveryModeSettings = await _applicationDbContext.DepartmentDeliveryModes
            .FirstOrDefaultAsync(ddm => ddm.DepartmentDeliveryModeId == departmentDeliveryModeId); 

        if (existingDepartmentDeliveryModeSettings == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department delivery mode settings not found");
        }

        _applicationDbContext.DepartmentDeliveryModes.Remove(existingDepartmentDeliveryModeSettings);
        await _applicationDbContext.SaveChangesAsync();
        return responseDTO.SetStatus(true).SetMessage("Department delivery mode settings successfully deleted");
    }

    public async Task<ResponseDTO> GetAllDepartmentRequestPaymentChannels()
    {
        var allDepartmentPaymentChannels = await _applicationDbContext.DepartmentRequestPaymentChannel.ToListAsync();
        if (allDepartmentPaymentChannels.Any())
        {
            return responseDTO.SetStatus(true).SetMessage("Department request payment channels found.").SetDataObject(allDepartmentPaymentChannels);
        }
        return responseDTO.SetStatus(false).SetMessage("No department payment channels settings found.");
    }

    public async Task<ResponseDTO> GetDepartmentRequestPaymentChannelByDepartmentRequestTypeId(Guid departmentRequestPaymentChannelId)
    {
        var departmentRequestPaymentChannel = await _applicationDbContext.DepartmentRequestPaymentChannel
            .FirstOrDefaultAsync(dmp => dmp.DepartmentRequestPaymentChannelId == departmentRequestPaymentChannelId);
        if (departmentRequestPaymentChannel == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department manual payment settings not found");
        }
        return responseDTO.SetStatus(true).SetMessage("Department manual payment settings found").SetDataObject(departmentRequestPaymentChannel);
    }

    public async Task<ResponseDTO> UpdateDepartmentRequestPaymentChannel(Guid departmentRequestPaymentChannelId, DepartmentRequestPaymentChannelDTO departmentRequestPaymentChannelDTO)
    {
        var existingDepartmentRequestPaymentChannel = await _applicationDbContext.DepartmentRequestPaymentChannel
            .FirstOrDefaultAsync(dmp => dmp.DepartmentRequestPaymentChannelId == departmentRequestPaymentChannelId);
        if (existingDepartmentRequestPaymentChannel == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department payment channel not found");
        }
        var properties = existingDepartmentRequestPaymentChannel.GetType().GetProperties();
        foreach (var property in properties)
        {
            var newValue = property.GetValue(departmentRequestPaymentChannelDTO);
            if (newValue != null)
            {
                property.SetValue(existingDepartmentRequestPaymentChannel,  newValue);
            }
        }
        await _applicationDbContext.SaveChangesAsync();
        return responseDTO.SetStatus(true).SetMessage("Department payment request payment updated successfully.");
    }

    public async Task<ResponseDTO> DeleteDepartmentRequestPaymentChannel(Guid departmentRequestPaymentChannelId)
    {
        var existingDepartmentRequestPaymentChannel = await _applicationDbContext.DepartmentRequestPaymentChannel
            .FirstOrDefaultAsync(dmp => dmp.DepartmentRequestPaymentChannelId == departmentRequestPaymentChannelId);
        if (existingDepartmentRequestPaymentChannel == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Department request payment channel not found");
        }
        _applicationDbContext.DepartmentRequestPaymentChannel.Remove(existingDepartmentRequestPaymentChannel);
        await _applicationDbContext.SaveChangesAsync();
        return responseDTO.SetStatus(true).SetMessage("Department request payment successfully deleted");
    }

    public async Task<ResponseDTO> CreateDepartmentRequestPaymentChannel(Guid departmentRequestTypeId)
    {
        // if (departmentRequestPaymentChannelDTO == null)
        // {
        //     return responseDTO.SetStatus(false).SetMessage("Department request payment channel settings cannot be empty");
        // }

        var departmentRequestTypeExists = await _applicationDbContext.DepartmentRequestTypes
            .AnyAsync(dpt => dpt.DepartmentRequestTypeId == departmentRequestTypeId);
        if (departmentRequestTypeExists)
        {
            return responseDTO.SetStatus(false).SetMessage("The specified Request Type does not exist.");
        }

        DepartmentRequestPaymentChannel departmentRequestPaymentChannel = new();
        departmentRequestPaymentChannel.DepartmentRequestTypeId = departmentRequestTypeId;

        try
        {
            await _applicationDbContext.DepartmentRequestPaymentChannel.AddAsync(departmentRequestPaymentChannel);
            var saveResult = await _applicationDbContext.SaveChangesAsync();
            if (saveResult > 0)
            {
                return responseDTO.SetStatus(true).SetMessage("Department request payment channel settings created successfully").SetDataObject(departmentRequestPaymentChannel);
            }
            return responseDTO.SetStatus(false).SetMessage("Failed to save the department payment type settings");
        }
        catch (Exception)
        {
            return responseDTO.SetStatus(false).SetMessage($"An unexpected error occurred. Please try again later.");
        }
    }

    // public async Task<ResponseDTO> GetDepartmentPaymentTypeById(Guid departmentPaymentTypeId)
    // {
    //     var departmentPaymentType = await _applicationDbContext.DepartmentPaymentTypes
    //         .FirstOrDefaultAsync(dpt => dpt.DepartmentPaymentTypeId == departmentPaymentTypeId);
    //     if (departmentPaymentType == null)
    //     {
    //         return responseDTO.SetStatus(false).SetMessage("Department payment type settings not found");
    //     }
    //     return responseDTO.SetStatus(true).SetMessage("Department payment type settings found").SetDataObject(departmentPaymentType);


    // }

    // public async Task<ResponseDTO> GetAllDepartmentPaymentType()
    // {
    //     var allDepartmentPaymentType = await _applicationDbContext.DepartmentPaymentTypes.ToListAsync();
    //     if (allDepartmentPaymentType.Any())
    //     {
    //         return responseDTO.SetStatus(true).SetMessage("Department payment type settings found.").SetDataObject(allDepartmentPaymentType);
    //     }
    //     return responseDTO.SetStatus(false).SetMessage("No department payment type settings found.");
    // }

    // public async Task<ResponseDTO> DeleteDepartmentPaymentType(Guid departmentPaymentTypeId)
    // {
    //     var existingDepartmentPaymentType = await _applicationDbContext.DepartmentPaymentTypes
    //         .FirstOrDefaultAsync(dpt => dpt.DepartmentPaymentTypeId == departmentPaymentTypeId);
    //     if (existingDepartmentPaymentType == null)
    //     {
    //         return responseDTO.SetStatus(false).SetMessage("Department payment type settings not found");
    //     }
    //     _applicationDbContext.DepartmentPaymentTypes.Remove(existingDepartmentPaymentType);
    //     await _applicationDbContext.SaveChangesAsync();
    //     return responseDTO.SetStatus(true).SetMessage("Department payment type settings successfully deleted");
    // }

    public async Task<ResponseDTO> UpdateRequestedReferee(Guid requestedRefereeId, RequestedReferee requestedReferee)
    {
        var existingRequestedReferee = await _applicationDbContext.RequestedReferees
            .FirstOrDefaultAsync(rr => rr.RequestedRefereeId == requestedRefereeId);
        if (existingRequestedReferee == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Requested Referee not found");
        }
        var properties = existingRequestedReferee.GetType().GetProperties();
        foreach (var property in properties)
        {
            var newValue = property.GetValue(requestedReferee);
            if (newValue != null)
            {
                property.SetValue(existingRequestedReferee, newValue);
            }
        }
        await _applicationDbContext.SaveChangesAsync();
        return responseDTO.SetStatus(true).SetMessage("Requested Referee updated successfully.");
    }

    public async Task<ResponseDTO> DeleteRequestedReferee(Guid requestedRefereeId)
    {
        var existingRequestedReferee = await _applicationDbContext.RequestedReferees
            .FirstOrDefaultAsync(rr => rr.RequestedRefereeId == requestedRefereeId);
        if (existingRequestedReferee == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Requested Referee not found");
        }
        _applicationDbContext.RequestedReferees.Remove(existingRequestedReferee);
        await _applicationDbContext.SaveChangesAsync();
        return responseDTO.SetStatus(true).SetMessage("Requested Referee successfully deleted");
    }

    public async Task<ResponseDTO> GetAllRequestedReferee()
    {
        var allRequestedRefree = await _applicationDbContext.RequestedReferees.ToListAsync();
        if (allRequestedRefree.Any())
        {
            return responseDTO.SetStatus(true).SetMessage("Requested Referee found.").SetDataObject(allRequestedRefree);
        }
        return responseDTO.SetStatus(false).SetMessage("No Requested Referee found.");
    }

    public async Task<ResponseDTO> GetRequestedRefereeById(Guid requestedRefereeId)
    {
        var requestedReferee = await _applicationDbContext.RequestedReferees
            .FirstOrDefaultAsync(rr => rr.RequestedRefereeId == requestedRefereeId);
        if (requestedReferee == null)
        {
            return responseDTO.SetStatus(false).SetMessage("Requested Referee not found");
        }
        return responseDTO.SetStatus(true).SetMessage("Requested Referee found").SetDataObject(requestedReferee);
    }


}
