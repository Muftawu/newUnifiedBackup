using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Shared.Application;
using Shared.Domain.Models;
using Shared.Infrastructure;
using DTOs;

namespace Shared.Infrastructure;

public class ApplicantService : IApplicantService
{
	private readonly ApplicationDbContext _applicationDbContext;
	private readonly UserManager<User> _userManager;
	private readonly ResponseDTO responseDTO = new ResponseDTO();

	public ApplicantService(ApplicationDbContext applicationDbContext, UserManager<User> userManager)
	{
		_applicationDbContext = applicationDbContext;
		_userManager = userManager;
	}

	public async Task<ResponseDTO> CreateApplicantRequest(Guid userId, Guid departmentRequestTypeId, RequestTransaction requestTransaction)
	{
		var userExist = await _userManager.FindByIdAsync(userId.ToString());

		var departmentRequestTypeExist = await _applicationDbContext.DepartmentRequestTypes.FirstOrDefaultAsync(d => d.DepartmentRequestTypeId == departmentRequestTypeId);

		if (userExist == null || departmentRequestTypeExist == null)
		{
			return responseDTO.SetStatus(false).SetMessage("User not found!");
		}

		var requestObj = new Request
		{
			UserId = userId,
			DepartmentRequestTypeId = departmentRequestTypeId
		};

		await _applicationDbContext.Requests.AddAsync(requestObj);
		var request = await _applicationDbContext.SaveChangesAsync();

		if (request > 0)
		{
			var requestExist = await _applicationDbContext.Requests.FirstOrDefaultAsync(r => r.RequestId == requestObj.RequestId);
			if (requestExist != null)
			{
				requestTransaction.RequestId = requestExist.RequestId;
				await _applicationDbContext.RequestTransactions.AddAsync(requestTransaction);
				await _applicationDbContext.SaveChangesAsync();
				return responseDTO.SetStatus(true).SetMessage("Request transaction created successfully!");
			}

			return responseDTO.SetStatus(false).SetMessage("Request transaction not created!");

		}

		return responseDTO.SetStatus(false).SetMessage("Request transaction not saved");

	}

	public async Task<ResponseDTO> GetAllApplicantRequest(Guid userId, Guid departmentRequestTypeId)
	{
		var requestExists = await _applicationDbContext.Requests.AsNoTracking()
		.AnyAsync(dr => dr.DepartmentRequestTypeId == departmentRequestTypeId);
        
		var userExist = await _userManager.FindByIdAsync(userId.ToString());

		if (!requestExists || userExist == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Request or user not found!");
		}

		var userRequest =  await _applicationDbContext.Requests
		.AsNoTracking()
		.Where(dr => dr.DepartmentRequestTypeId == departmentRequestTypeId)
		.Where(u => u.UserId == userId)
		.ToListAsync();

		return responseDTO.SetStatus(true).SetMessage("Request found!").SetDataObject(userRequest);
	}

	public async Task<ResponseDTO> GetApplicantRequestTransaction(Guid userId, Guid requestId)
	{
		var requestExists = await _applicationDbContext.Requests.FirstOrDefaultAsync(r => r.RequestId == requestId);
		var userExist = await _userManager.FindByIdAsync(userId.ToString());

		if (requestExists == null || userExist == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Request or user not found!");
		}

		var requestTransactions = await _applicationDbContext.RequestTransactions.AsNoTracking()
		.Where(r => r.RequestId == requestId)
		.ToListAsync();

		return responseDTO.SetStatus(true).SetMessage("Request Transactions found!").SetDataObject(requestTransactions);
	}

	public async Task<ResponseDTO> GetApplicantRequestById(Guid requestId)
	{
		var requestExists = await _applicationDbContext.Requests.FirstOrDefaultAsync(r => r.RequestId == requestId);

		if (requestExists == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Request not found!");
		}

		return responseDTO.SetStatus(true).SetMessage("Applicant Request found!").SetDataObject(new List<Request> { requestExists });
	}



	public async Task<ResponseDTO> DeleteApplicantRequest(Guid userId, Guid departmentRequestTypeId)
	{
		var requestExists = await _applicationDbContext.Requests.AsNoTracking().FirstOrDefaultAsync(dr => dr.DepartmentRequestTypeId == departmentRequestTypeId);
        
		var userExist = await _userManager.FindByIdAsync(userId.ToString());


		if (requestExists == null|| userExist == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Request or user not found!");
		}
		_applicationDbContext.Requests.Remove(requestExists);
		await _applicationDbContext.SaveChangesAsync();
		return responseDTO.SetStatus(true).SetMessage("Request deleted successfully!");
	}

	public async Task<ResponseDTO> GetApplicantProgrammesRead(Guid userId)
	{
		var applicantProgrammeReadExist = await _applicationDbContext.ProgrammeReads
            .Where(pr => pr.UserId == userId)
            .ToListAsync();

		if (applicantProgrammeReadExist == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Applicant programmes read not found!");
		}

		return responseDTO.SetStatus(true).SetMessage("Found applicant programme read!").SetDataObject(applicantProgrammeReadExist);
	}

	
	public async Task<ResponseDTO> GetApplicantIdentification(Guid userId)
	{
		var identificationExist = await _applicationDbContext.IdentificationCards.FirstOrDefaultAsync(id => id.UserId == userId);

		if (identificationExist == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Identification not found!");
		}

		return responseDTO.SetStatus(true).SetMessage("Identification found!").SetDataObject(new List<IdentificationCard> { identificationExist });
	}


}
