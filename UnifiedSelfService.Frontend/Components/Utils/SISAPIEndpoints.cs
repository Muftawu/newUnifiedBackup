namespace Frontend.Endpoints;

public static class SISAPIEndpoints
{
    private static string sis_version = "1";

    public static string GetAllDepartments = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Departments";
    
    public static string GetDepartmentDetails = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Departments";

    public static string GetAllProgrammes = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Programme";
    
    public static string GetProgrammeById = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Departments/Programme";

    public static string GetCollegeById = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/College";
    
    public static string GetFacultyById = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Faculty";

    public static string GetAllCountries = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Country";

    public static string GetAllGraduateTypes = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/GraduateType";

    public static string UpdateDepartmentGeneralSettings = $"https://dev.knust.edu.gh/sisapi/api/v{sis_version}/Departments";
   
}
