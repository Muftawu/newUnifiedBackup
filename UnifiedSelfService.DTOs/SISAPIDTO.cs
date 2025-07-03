using System.Text.Json.Serialization;

namespace DTOs;

public class CollegeDTO 
{
    [JsonPropertyName("collegeId")]
    public int? CollegeId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("head")]
    public string? Head { get; set; }
    
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }
    
    [JsonPropertyName("phoneExt")]
    public string? PhoneExt { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
    
    [JsonPropertyName("collegeCode")]
    public string? CollegeCode { get; set; }

    [JsonPropertyName("registrationEmail")]
    public string? RegistrationEmail { get; set; }
}


public class FacultyDTO 
{
    [JsonPropertyName("facultyId")]
    public int? FacultyId { get; set; }

    [JsonPropertyName("collegeId")]
    public int? CollegeId { get; set; }

    [JsonPropertyName("facultyName")]
    public string? FacultyName { get; set; }

    [JsonPropertyName("facultyHead")]
    public string? FacultyHead { get; set; }
    
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }
    
    [JsonPropertyName("phoneExt")]
    public string? PhoneExt { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
    
    [JsonPropertyName("facultyCode")]
    public string? FacultyCode { get; set; }
}


public class CountryDTO
{
    [JsonPropertyName("countryId")]
    public string? CountryId { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nationality")]
    public string? Nationality { get; set; }

    [JsonPropertyName("phoneCode")]
    public string? PhoneCode { get; set; }
}

public class GraduateTypeDTO
{
    [JsonPropertyName("graduateTypeId")]
    public int? GraduateTypeId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}


