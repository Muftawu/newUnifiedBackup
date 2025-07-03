using DTOs;
using Shared.Domain.Models; 
namespace Shared.Application;

public interface IDeveloperSettingsService
{
    Task<ResponseDTO> CreateRequestType(RequestType requestType);

    Task<ResponseDTO> GetAllRequestTypes();

    Task<ResponseDTO> GetRequestTypeById(Guid requestypeId);

    Task<ResponseDTO> CreateDeliveryMode(DeliveryMode deliverymode);

    Task<ResponseDTO> GetAllDeliveryModes();

    Task<ResponseDTO> DeleteRequestType(Guid requestTypeId);

    Task<ResponseDTO> GetAllPaymentTypes();

    // Add Department
    Task<ResponseDTO> CreateSubscribedDepartment(Department subscribedDepartment, bool generateCredential, string adminEmail);

    Task<ResponseDTO> GetAllSubscribedDepartments();

    Task<ResponseDTO> GetDepartmentRequestTypeByName(string requestypeName);

    Task<ResponseDTO> GetDepartmentRequestTypeById(Guid departmentRequestTypeId);

    Task<ResponseDTO> GetSubscribedDepartmentById(int DepartmentId);

    Task<ResponseDTO> CreateDepartmentRequestType(DepartmentSubscriptionDTO departmentSubscriptionDTO);

    Task<ResponseDTO> GetAllDepartmentRequestTypesByDepartmentId(int DepartmentId);

    Task<ResponseDTO> GetAllDepartmentRequestTypes();

    Task<ResponseDTO> GetAllRequestTransactions();

  


  

}



