using DTOs;
using Shared.Domain.Models;
namespace Shared.Application;

public interface IAdminService
{
    public Task<ResponseDTO> GetAllApplicantRequests(int pageNumber, int pageSize, Guid departmentRequestTypeId);

    public Task<ResponseDTO> VerifyApplicantRequest(Guid requestTransactionId);

}