using System.Text.Json.Serialization;
using Shared.Domain.Models;

namespace GenericResponse;

public class GenericResponseDTO<T>
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("dataObject")]
    public List<T>? Data { get; set; }
}

public class GenericResponseDTOPost
{
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

public class GenericResponseDTOPostLogin
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("userType")]
    public string? UserType { get; set; }
}

public class SISResponseDTOMultiple<T>
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    [JsonPropertyName("data")]
    public List<T>? Data { get; set; }
}

public class SISResponseDTOSingle<T>
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    [JsonPropertyName("data")]
    public T? Data { get; set; }
}

public class DepartmentInfoDTO
{
    [JsonPropertyName("departmentId")]
    public int? DepartmentId { get; set; }

    [JsonPropertyName("departmentName")]
    public string? DepartmentName { get; set; }
    
    [JsonPropertyName("programmes")]
    public List<Programme>? Programmes { get; set; }
}

public class GetProgrammeByIdDTO
{
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }
    
    [JsonPropertyName("data")]
    public DepartmentInfoDTO? Data{ get; set; }

}

public class ErrorResponse
{
    [JsonPropertyName("type")]
    public string? Type{ get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("message")]
    public int? Status { get; set; }
    
    [JsonPropertyName("errors")]
    public Dictionary<string, string[]> Errors { get; set; }
 
    [JsonPropertyName("traceId")]
    public string? TraceId { get; set; }
}


