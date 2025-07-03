using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Shared.Application;
using Shared.Domain.Models;
using Shared.Infrastructure;
using DTOs;

namespace Shared.Infrastructure;


public class AdminService : IAdminService
{
	private readonly ApplicationDbContext _applicationDbContext;
	private readonly UserManager<User> _userManager;
	private readonly ResponseDTO responseDTO = new ResponseDTO();

	public AdminService(ApplicationDbContext applicationDbContext, UserManager<User> userManager)
	{
		_applicationDbContext = applicationDbContext;
		_userManager = userManager;
	}


	public async Task<ResponseDTO> GetAllApplicantRequests(int pageNumber, int pageSize, Guid departmentRequestTypeId)
	{
		var requests = await _applicationDbContext.Requests.AsNoTracking().Where(dr => dr.DepartmentRequestTypeId == departmentRequestTypeId).Skip((pageNumber - 1) * pageSize).ToListAsync();

		var totalRecords = await _applicationDbContext.Requests.AsNoTracking().Where(dr => dr.DepartmentRequestTypeId == departmentRequestTypeId).Skip((pageNumber - 1) * pageSize).CountAsync();

		var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

		var paginationMetaData = new{
        TotalRecords = totalRecords,
        TotalPages = totalPages,
        PageSize = pageSize,
        CurrentPage = pageNumber,
        HasNextPage = pageNumber < totalPages,
        HasPreviousPage = pageNumber > 1
    };

		if (requests == null || !requests.Any())
		{
			return responseDTO.SetStatus(false).SetMessage("No request transaction found!");
		}

		return responseDTO.SetStatus(true).SetMessage("Request transactions found!").SetDataObject(requests).SetMetaData(paginationMetaData);
	}

	public async Task<ResponseDTO> VerifyApplicantRequest(Guid requestTransactionId)
	{
		var requestTransaction = await _applicationDbContext.RequestTransactions
			.FirstOrDefaultAsync(r => r.RequestTransactionId == requestTransactionId);

		if (requestTransaction == null)
		{
			return responseDTO.SetStatus(false).SetMessage("Request Transaction not found!");
		}

		requestTransaction.ProcessingStatus = "Completed";

		_applicationDbContext.RequestTransactions.Update(requestTransaction);
		await _applicationDbContext.SaveChangesAsync();

		return responseDTO.SetStatus(true).SetMessage("Request Transaction successfully verified!");
	}


}