using Microsoft.EntityFrameworkCore;
using Shared.Application;
using System.Threading.Tasks;
using Shared.Domain.Models;
using DTOs;
using Shared.Infrastructure;

public class DeveloperSettingsService : IDeveloperSettingsService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IAuthService _authService;

    public DeveloperSettingsService(ApplicationDbContext applicationDbContext, IAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    //........................................................................................................................................

    public async Task<ResponseDTO> CreateRequestType(RequestType requestType)
    {
        if (requestType == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Request type cannot be null"
            };
        }

        try
        {
            await _applicationDbContext.RequestTypes.AddAsync(requestType);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                return new ResponseDTO
                {
                    Status = true,
                    Message = "Request type created successfully",
                    DataObject = new List<RequestType> { requestType },
                };
            }

            return new ResponseDTO
            {
                Status = false,
                Message = "Failed to create the request type",
            };

        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }

    public async Task<ResponseDTO> GetAllRequestTypes()
    {
        try
        {
            var results = await _applicationDbContext.RequestTypes.ToListAsync();

            if (results == null)
            {
                return new ResponseDTO { Status = false, Message = "Failed to fetch data" };
            }

            return new ResponseDTO { Status = true, Message = "Successfully fetched all requests", DataObject = results };

        }
        catch (Exception ex)
        {
            return new ResponseDTO { Status = false, Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}" };
        }
    }


    public async Task<ResponseDTO> GetRequestTypeById(Guid requestTypeId)
    {
        var requestType = await _applicationDbContext.RequestTypes.FirstOrDefaultAsync(x => x.RequestTypeId == requestTypeId);
        if (requestType == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No request type found"
            };
        }
        return new ResponseDTO
        {
            Status = true,
            Message = "Found department request type",
            DataObject = new List<RequestType> { requestType }
        };
    }

    public async Task<ResponseDTO> GetDepartmentRequestTypeByName(string requestTypeName)
    {
        if (string.IsNullOrEmpty(requestTypeName))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Request type name cannot be null"
            };
        }

        var requestType = await _applicationDbContext.DepartmentRequestTypes
            .Include(rt => rt.RequestType)
            .FirstOrDefaultAsync(request => request.RequestType.Name == requestTypeName);

        if (requestType == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No request type found"
            };
        }
        return new ResponseDTO
        {
            Status = true,
            Message = "Found department request type",
            DataObject = new List<DepartmentRequestType> { requestType }
        };
    }

    public async Task<ResponseDTO> GetDepartmentRequestTypeById(Guid departmentRequestTypeId)
    {
        if (string.IsNullOrEmpty(departmentRequestTypeId.ToString()))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Department request type cannot be null"
            };
        }

        var deptRequestType = await _applicationDbContext.DepartmentRequestTypes
            .Include(rt => rt.RequestType)
            .FirstOrDefaultAsync(request => request.DepartmentRequestTypeId == departmentRequestTypeId);

        if (deptRequestType == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No department request type request type found"
            };
        }
        return new ResponseDTO
        {
            Status = true,
            Message = "Found department request type",
            DataObject = new List<DepartmentRequestType> { deptRequestType }
        };
    }

    public async Task<ResponseDTO> GetAllDepartmentRequestTypesByDepartmentId(int departmentId)
    {
        var departmentRequestTypes = await _applicationDbContext.DepartmentRequestTypes
        .Include(rt => rt.RequestType)
        .Where(rt => rt.SISDeptId == departmentId).ToListAsync();

        if (departmentRequestTypes == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No request type found",
                DataObject = new List<DepartmentRequestType>()
            };
        }

        return new ResponseDTO
        {
            Status = true,
            Message = "Found department request type",
            DataObject = departmentRequestTypes
        };
    }

    public async Task<ResponseDTO> DeleteRequestType(Guid requestTypeId)
    {
        if (string.IsNullOrEmpty(requestTypeId.ToString()))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Request type cannot be null"
            };
        }

        var requestType = await _applicationDbContext.RequestTypes
            .FirstOrDefaultAsync(request => request.RequestTypeId == requestTypeId);

        if (requestType == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No Request type request type found"
            };
        }

        // delete goes here
        _applicationDbContext.RequestTypes.Remove(requestType);
        await _applicationDbContext.SaveChangesAsync();
        return new ResponseDTO
        {
            Status = true,
            Message = "Request Type deleted successfully",
            DataObject = new List<RequestType> { requestType }
        };

    }


    //..............................................................................................

    public async Task<ResponseDTO> CreateDeliveryMode(DeliveryMode deliverymode)
    {
        if (deliverymode == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Delivery mode cannot be null"
            };
        }

        try
        {
            await _applicationDbContext.DeliveryModes.AddAsync(deliverymode);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                return new ResponseDTO
                {
                    Status = true,
                    Message = "Saved Successfully",
                    DataObject = deliverymode
                };
            }

            return new ResponseDTO
            {
                Status = false,
                Message = "Failed to create the delivery mode",
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }


    public async Task<ResponseDTO> GetAllDeliveryModes()
    {
        try
        {
            var results = await _applicationDbContext.DeliveryModes.ToListAsync();

            if (results == null)
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Failed to fetch data",
                };
            }

            return new ResponseDTO
            {
                Status = true,
                Message = "Successfully fetched all requests",
                DataObject = results
            };

        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }

    //..............................................................................................................................

    public async Task<ResponseDTO> GetAllPaymentTypes()
    {
        try
        {
            var results = await _applicationDbContext.DepartmentRequestPaymentChannel.ToListAsync();

            if (results == null)
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Failed to fetch data",
                };
            }

            return new ResponseDTO
            {
                Status = true,
                Message = "Successfully fetched all requests",
                DataObject = results
            };

        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }

    public async Task<ResponseDTO> GetSubscribedDepartmentByName(string subscribedDepartmentName)
    {
        if (string.IsNullOrEmpty(subscribedDepartmentName))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Subscribed Department name cannot be null"
            };
        }

        var subscribedDepartment = await _applicationDbContext.Departments
            .FirstOrDefaultAsync(department => department.DepartmentName == subscribedDepartmentName);

        if (subscribedDepartment == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "No department type found"
            };
        }
        return new ResponseDTO
        {
            Status = true,
            Message = "Found department",
            DataObject = new List<Department> { subscribedDepartment }
        };
    }


    //..................................................................................................................
    public async Task<ResponseDTO> CreateSubscribedDepartment(Department department, bool generateCredential, string adminEmail)
    {
        if (department == null || string.IsNullOrEmpty(adminEmail))
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Department subscription cannot be null"
            };
        }

        var newDepartmentName = department.DepartmentName;
        var isDepartmentExist = await GetSubscribedDepartmentByName(newDepartmentName);

        if (isDepartmentExist.Status)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Department already exists"
            };
        }

        try
        {
            await _applicationDbContext.Departments.AddAsync(department);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                if (generateCredential)
                {
                    var pguid = Guid.NewGuid().ToString().Trim(' ');
                    string password = $"Admin{pguid.Substring(0, 4).ToLower()}@2024";
                    Console.WriteLine($"password: {password}");

                    var registerDTO = new RegisterDTO
                    {
                        Email = adminEmail,
                        UserType = UserRoles.DepartmentAdmin,
                        Password = password,
                        ConfirmPassword = password
                    };

                    var register_response = await _authService.Register(registerDTO);

                    if (register_response.Status)
                    {
                        return new ResponseDTO
                        {
                            Status = true,
                            Message = $"Department subscription created successfully and credential successfully generated {adminEmail} : {password}",
                            DataObject = department
                        };
                    }
                    else
                    {
                        Console.WriteLine($"Failed to generate default user credentials: {register_response.Message}");
                        return new ResponseDTO
                        {
                            Status = false,
                            Message = $"Failed to generate default user credentials: {password}: {register_response.Message}",
                        };
                    }
                }

                return new ResponseDTO
                {
                    Status = true,
                    Message = "Department subscription created successfully",
                    DataObject = department,
                };
            }

            return new ResponseDTO
            {
                Status = false,
                Message = "Failed to create department subscription.",
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }

    public async Task<ResponseDTO> GetAllSubscribedDepartments()
    {
        try
        {
            var results = await _applicationDbContext.Departments.ToListAsync();

            if (results == null)
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Failed to fetch data",
                };
            }

            return new ResponseDTO
            {
                Status = true,
                Message = "Successfully fetched all requests",
                DataObject = results
            };

        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }

    public async Task<ResponseDTO> GetAllRequestTransactions()
    {
        try
        {
            var results = await _applicationDbContext.RequestTransactions.ToListAsync();

            if (results == null)
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Failed to all request Transactions",
                };
            }

            return new ResponseDTO
            {
                Status = true,
                Message = "Successfully fetched all request transactions",
                DataObject = results
            };

        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message} Inner Exception: {ex.InnerException?.Message}",
            };
        }
    }

    public async Task<ResponseDTO> GetSubscribedDepartmentById(int departmentId)
    {
        var department = await _applicationDbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
        if (department == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Department subscription not found"
            };
        }
        return new ResponseDTO
        {
            Status = true,
            Message = "Department subscription found",
            DataObject = new List<Department> { department }
        };
    }


    public async Task<ResponseDTO> CreateDepartmentRequestType(DepartmentSubscriptionDTO departmentSubscriptionDTO)
    {
        var requestType = await _applicationDbContext.RequestTypes
            .FirstOrDefaultAsync(x => x.RequestTypeId.ToString() == departmentSubscriptionDTO.RequestTypeId);

        if (requestType == null)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = "Request type not found"
            };
        }

        try
        {
            // Assign IDs
            DepartmentRequestType departmentRequestType = new();
            departmentRequestType.SISDeptId = departmentSubscriptionDTO.SISDeptId;
            departmentRequestType.RequestTypeId = Guid.Parse(departmentSubscriptionDTO.RequestTypeId);

            // Add to database
            await _applicationDbContext.DepartmentRequestTypes.AddAsync(departmentRequestType);
            var saveResult = await _applicationDbContext.SaveChangesAsync();

            if (saveResult > 0)
            {
                return new ResponseDTO
                {
                    Status = true,
                    Message = "Department request type created successfully",
                    DataObject = departmentRequestType,
                };
            }

            return new ResponseDTO
            {
                Status = false,
                Message = "Failed to save the department request type to the database.",
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                Status = false,
                Message = $"An error occurred: {ex.Message}{(ex.InnerException != null ? $" Inner Exception: {ex.InnerException.Message}" : "")}",
            };
        }
    }

    public async Task<ResponseDTO> GetAllDepartmentRequestTypes()
    {
        var departmentRequestTypes = await _applicationDbContext.DepartmentRequestTypes
            .Include(rt => rt.RequestType)
            .ToListAsync();

        if (departmentRequestTypes.Any())
        {
            return new ResponseDTO
            {
                Status = true,
                Message = "Results found",
                DataObject = departmentRequestTypes
            };
        }
        return new ResponseDTO
        {
            Status = false,
            Message = "No request types found",
        };
    }


   


}




