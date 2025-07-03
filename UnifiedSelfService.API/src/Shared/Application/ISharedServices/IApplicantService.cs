using DTOs;
using Shared.Domain.Models;
namespace Shared.Application;

public interface IApplicantService
{
    public Task<ResponseDTO> CreateApplicantRequest(Guid userId, Guid departmentRequestTypeId, RequestTransaction requestTransaction );

    public Task<ResponseDTO> GetAllApplicantRequest(Guid userId, Guid departmentRequestTypeId);

    public Task<ResponseDTO> GetApplicantRequestById(Guid requestId);

    public Task<ResponseDTO> GetApplicantRequestTransaction(Guid userId, Guid requestId);

    public Task<ResponseDTO> DeleteApplicantRequest(Guid userId, Guid departmentRequestTypeId);

    public Task<ResponseDTO> GetApplicantProgrammesRead(Guid userId);

    public Task<ResponseDTO> GetApplicantIdentification(Guid userId);

}
