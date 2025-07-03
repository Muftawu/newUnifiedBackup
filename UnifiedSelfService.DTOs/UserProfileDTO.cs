using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Shared.Domain.Models;

public class UserDTO
{
    public string Email { get; set; }

    public string ReferenceNumber { get; set; }

    public string IndexNumber { get; set; }

    [Required(ErrorMessage = "Surname is required")]
    public string Surname { get; set; }
    
    [Required(ErrorMessage = "Other name is required")]
    public string OtherNames { get; set; }
    
    [Required(ErrorMessage = "Gender is required")]
    public string Gender { get; set; }
    
    [Required(ErrorMessage = "Date of birth is required")]
    public DateTime? DateOfBirth { get; set; }
    
    [Required(ErrorMessage = "Country code is required")]
    public string CountryCode { get; set; } = "+233";
    
    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\+?\d{9,15}$", ErrorMessage = "Phone number must be between 9 and 15 digits")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "Country of residence is required")]
    public string CountryOfResidence { get; set; } = "Ghana";

    [Required(ErrorMessage = "Identification Card File  is required")]
    public byte[] PassportPicture { get; set; } = Array.Empty<byte>();
}

public class IdentificationCardDTO
{
    [Required(ErrorMessage = "Identification Card Type is required")]
    public string IdentificationCardType { get; set; }
    
    [Required(ErrorMessage = "Identification Card Number  is required")]
    public string IdentificationCardNumber { get; set; }

    [Required(ErrorMessage = "Identification Card File  is required")]
    public byte[] IdentificationCardFile { get; set; }
    
}

public class ProgrammesReadDTO
{    
    [Required(ErrorMessage = "FullNameOnCertificate is required")]
    public string FullNameOnCertificate { get; set; }

    [Required(ErrorMessage = "StudentNumber is required")]
    public string StudentNumber { get; set; }

    [Required(ErrorMessage = "IndexNumber is required")]
    public string IndexNumber { get; set; }

    [Required(ErrorMessage = "ProgrammeOfStudy is required")]
    public int? ProgrammeId { get; set; }

    [Required(ErrorMessage = "AdmissionYear is required")]
    public string AdmissionYear { get; set; }

    [Required(ErrorMessage = "GraduationYear is required")]
    public string GraduationYear { get; set; }

    // [Required(ErrorMessage = "ThesisTopic is required")]
    public string ThesisTopic { get; set; }

    [Required(ErrorMessage = "GraduateType is required")]
    public string? GraduateType { get; set; }

}


public class CreateUserProfileDTO
{
    [JsonPropertyName("userDTO")]
    public UserDTO userDTO { get; set; }
    
    [JsonPropertyName("identificationCardDTO")]
    public IdentificationCardDTO identificationCardDTO { get; set; }

    [JsonPropertyName("programmesReadDTO")]
    public ProgrammesReadDTO programmesReadDTO { get; set; } [JsonPropertyName("userId")]
    public string userId { get; set; }

}
