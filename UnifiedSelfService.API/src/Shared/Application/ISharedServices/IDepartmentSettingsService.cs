using DTOs;
using Shared.Domain.Models;
namespace Shared.Application;

public interface IDepartmentSettingsService
{
    
    // C.R.U.D OPERATIONS ON DEPARTMENT PROFILE.

    Task<ResponseDTO> CreateDepartmentProfile(int departmentId, DepartmentSetting departmentSetting);

    Task<ResponseDTO> GetDepartmentProfileById(Guid departmentSettingsId);

    Task<ResponseDTO> GetAllDepartmentProfile();

    Task<ResponseDTO> UpdateDepartmentProfile(Guid departmentSettingsId, DepartmentSetting departmentSetting);

    Task<ResponseDTO> DeleteDepartmentProfile(Guid departmentSettingsId);
    

    //C.R.U.D OPERATIONS ON DELIVERY MODE SETTINGS.

    Task<ResponseDTO> CreateDepartmentDeliveryModeSettings(Guid requestTypeId, DepartmentDeliveryMode departmentDeliveryModeId);

    Task<ResponseDTO> GetAllDepartmentDeliveryModeSettings();

    Task<ResponseDTO> GetDepartmentDeliveryModeSettingsById(Guid departmentDeliveryModeId);

    Task<ResponseDTO> UpdateDepartmentDeliveryModeSettings(Guid departmentDeliveryModeId, DepartmentDeliveryMode departmentDeliveryMode);

    Task<ResponseDTO> DeleteDepartmentDeliveryModeSettings(Guid departmentDeliveryModeId);



    //C.R.U.D OPERATIONS FOR DEPARTMENT PAYMENT SETTINGS.
    Task<ResponseDTO> CreateDepartmentRequestPaymentChannel(Guid departmentRequestTypeId);

    Task<ResponseDTO> GetDepartmentRequestPaymentChannelByDepartmentRequestTypeId(Guid departmentRequestTypeId);

    Task<ResponseDTO> GetAllDepartmentRequestPaymentChannels();

    Task<ResponseDTO> UpdateDepartmentRequestPaymentChannel(Guid departmentRequestPaymentChannelId, DepartmentRequestPaymentChannelDTO departmentRequestPaymentChannelDTO);

    Task<ResponseDTO> DeleteDepartmentRequestPaymentChannel(Guid departmentRequestPaymentChannelId);


    // C.R.U.D OPERATIONS ON REQUESTED REFEREE.
    //Task<ResponseDTO> CreateRequestedReferee(Guid refereeId, Guid recommendationId, RequestedReferee requestedReferee);

    Task<ResponseDTO> UpdateRequestedReferee(Guid requestedRefereeId, RequestedReferee requestedReferee);

    Task<ResponseDTO> DeleteRequestedReferee(Guid requestedRefereeId);

    Task<ResponseDTO> GetAllRequestedReferee();

    Task<ResponseDTO> GetRequestedRefereeById(Guid requestedRefereeId);

}










