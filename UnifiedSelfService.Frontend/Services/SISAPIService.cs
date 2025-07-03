using Shared.Domain.Models;
using DTOs;
using GenericResponse;
using Frontend.Endpoints;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DTOs; 
namespace Frontend.Services;

public class SISAPIService
{
    private readonly HttpClient _httpClient;

    public SISAPIService (HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(bool Status, List<Department> departments)> GetAllDepartments () 
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOMultiple<Department>>(SISAPIEndpoints.GetAllDepartments);
            if (response?.Data != null)
            {
                return (true, response.Data);
            }
            return (false, new List<Department>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SISAPI] An error occurred from: {ex.Message}");
            return (false, new List<Department>());
        }
    }

    public async Task<(bool Status, Department department)> GetDepartmentDetails(int? departmentId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOSingle<Department>>($"{SISAPIEndpoints.GetDepartmentDetails}/{departmentId}");
            var department = response?.Data!; 
            if (department != null)
            {
                return (true, department!);
            }
            return (false, new Department());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from SISAPI: get department by id {ex.Message}");
            return (false, new Department());
        }
    }
    
    public async Task<(bool Status, List<Programme> programmes)> GetAllProgrammes()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOMultiple<Programme>>($"{SISAPIEndpoints.GetAllProgrammes}");
            var programmes = response?.Data!; 
            if (programmes != null)
            {
                return (true, programmes!);
            }
            return (false, new List<Programme>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from SISAPI: fetching all programmes {ex.Message}");
            return (false, new List<Programme>());
        }
    }

    public async Task<(bool Status, int? departmentId, string departmentName, List<Programme> programmes)> GetProgrammeDetails(int? programmeId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<GetProgrammeByIdDTO>($"{SISAPIEndpoints.GetProgrammeById}/{programmeId}");
            var data = response.Data;
            if (data != null)
            {
                return (true, data.DepartmentId, data.DepartmentName, data.Programmes!);
            }
            return (false, 0, string.Empty, new List<Programme>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured from SISAPI: fetching all departments {ex.Message}");
            return (false, 0, string.Empty, new List<Programme>());
        }
    }
 
    public async Task<(bool Status, CollegeDTO college)> GetCollegeById (int? collegeId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOSingle<CollegeDTO>>($"{SISAPIEndpoints.GetCollegeById}/{collegeId}");
            var data = response.Data;
            if (data != null)
            {
                return (true, data);
            }
            return (false, new CollegeDTO());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SISAPI Error] getting college by id {ex.Message}");
            return (false, new CollegeDTO());
        }
    }

    public async Task<(bool Status, FacultyDTO faculty)> GetFacultyById (int? facultyId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOSingle<FacultyDTO>>($"{SISAPIEndpoints.GetFacultyById}/{facultyId}");
            var data = response.Data;
            if (data != null)
            {
                return (true, data);
            }
            return (false, new FacultyDTO());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SISAPI Error] getting faculty by id {ex.Message}");
            return (false, new FacultyDTO());
        }
    }

    public async Task<(bool Status, List<CountryDTO> countries)> GetAllCountries()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOMultiple<CountryDTO>>($"{SISAPIEndpoints.GetAllCountries}");
            var data = response.Data;
            if (data != null)
            {
                return (true, data);
            }
            return (false, new List<CountryDTO>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SISAPI Error] getting all countries: {ex.Message}");
            return (false, new List<CountryDTO>());
        }
    }
    
    public async Task<(bool Status, List<GraduateTypeDTO> graduateTypes)> GetGraduateTypes()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOMultiple<GraduateTypeDTO>>($"{SISAPIEndpoints.GetAllGraduateTypes}");
            var data = response.Data;
            if (data != null)
            {
                return (true, data);
            }
            return (false, new List<GraduateTypeDTO>());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SISAPI Error] getting all graudate types : {ex.Message}");
            return (false, new List<GraduateTypeDTO>());
        }
    }

    public async Task<(bool Status, string Message)> UpdateDepartmentGeneralSettingsInfo()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<SISResponseDTOSingle<Department>>($"{SISAPIEndpoints.UpdateDepartmentGeneralSettings}");
            var data = response.Data;
            if (data != null)
            {
                return (true, response.Message);
            }
            return (false, response.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[SISAPI Error] getting all graudate types : {ex.Message}");
            return (false, $"{ex.Message}");
        }
    }


}
