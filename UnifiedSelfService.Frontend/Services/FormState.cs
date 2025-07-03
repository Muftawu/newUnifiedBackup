using System;
using Shared.Domain.Models;

namespace Frontend.Services;

public class NewRequestFormState
{
    public string ProcessingStatus { get; set; } = string.Empty;
    public string ProgrammeOfStudy { get; set; } = string.Empty;
    public string DeliveryModeOption { get; set; } = string.Empty;
    public string RecipientEmail { get; set; } = string.Empty;
    public string RecipientName { get; set; } = string.Empty;

    public void Clear()
    {
        ProgrammeOfStudy = string.Empty;
        DeliveryModeOption = string.Empty;
        RecipientEmail = string.Empty;
        RecipientName = string.Empty;
        ProcessingStatus = string.Empty;
    }
}

// public class PersonalInformationFormState
// {
//     public string Email { get; set; } = string.Empty;
//     public string ReferenceNumber { get; set; } = string.Empty;
//     public string IndexNumber { get; set; } = string.Empty;
//     public string Surname { get; set; } = string.Empty;
//     public string OtherNames { get; set; } = string.Empty;
//     public string Gender { get; set; } = string.Empty;
//     public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;
//     public string CountryCode { get; set; } = string.Empty;
//     public string PhoneNumber { get; set; } = string.Empty;
//     public string CountryOfResidence { get; set; } = string.Empty;
//     public byte[] PassportPicture { get; set; } = Array.Empty<byte>();

//     public void Clear()
//     {
//         Email = string.Empty;
//         ReferenceNumber = string.Empty;
//         IndexNumber = string.Empty;
//         Surname = string.Empty;
//         OtherNames = string.Empty;
//         Gender = string.Empty;
//         DateOfBirth = DateTime.Now.Date;
//         CountryCode = string.Empty;
//         PhoneNumber = string.Empty;
//         CountryOfResidence = string.Empty;
//         PassportPicture = Array.Empty<byte>();
//     }
// }

// public class IdentificationCardStateForm
// {
//     public string IdentificationCardType { get; set; } = string.Empty;
//     public string IdentificationCardNumber { get; set; } = string.Empty;
//     public byte[] IdentificationCardFile { get; set; } = Array.Empty<byte>();

//     public void Clear()
//     {
//         IdentificationCardType = string.Empty;
//         IdentificationCardNumber = string.Empty;
//         IdentificationCardFile = Array.Empty<byte>();
//     }
// }

// public class ProgrammesReadFormState
// {
//     public string FullNameOnCertificate { get; set; } = string.Empty;
//     public string StudentNumber { get; set; } = string.Empty;
//     public string IndexNumber { get; set; } = string.Empty;
//     public string ReferenceNumber { get; set; } = string.Empty;
//     public int? ProgrammeId { get; set; } = null;
//     public string AdmissionYear { get; set; } = string.Empty;
//     public string GraduationYear { get; set; } = string.Empty;
//     public GraduateTypes GraduateType { get; set; } = GraduateTypes.Undergraduate;
//     public string ThesisTopic { get; set; } = string.Empty;

//     public void Clear()
//     {
//         FullNameOnCertificate = string.Empty;
//         StudentNumber = string.Empty;
//         IndexNumber = string.Empty;
//         ReferenceNumber = string.Empty;
//         ProgrammeId = null;
//         AdmissionYear = string.Empty;
//         GraduationYear = string.Empty;
//         GraduateType = GraduateTypes.Undergraduate;
//         ThesisTopic = string.Empty;
//     }
// }


public class DepartmentGeneralInformationSettingsFormState
{
    public string DepartmentName { get; set; } = string.Empty;
    public byte[] DepartmentLogo { get; set; } = Array.Empty<byte>();
    public string? DepartmentHOD { get; set; } = string.Empty;
    public string? DepartmentEmail { get; set; } = string.Empty;
    public string? DepartmentTelephone { get; set; } = string.Empty;

    public void Clear()
    {
        DepartmentName = string.Empty;
        DepartmentLogo = Array.Empty<byte>();
        DepartmentHOD = string.Empty;
        DepartmentEmail = string.Empty;
        DepartmentTelephone = string.Empty;
    }
}

public class DepartmentAdministrativeSettingsFormState
{
    public byte[] DepartmentHODSignature { get; set; } = Array.Empty<byte>();
    public byte[] DepartmentStamp { get; set; } = Array.Empty<byte>();
    public string? DepartmentWorkingHours { get; set; } = string.Empty;
    public bool DepartmentPortalStatus { get; set; } = false;
    public string? DepartmentPortalMessage { get; set; } = string.Empty;

    public void Clear()
    {
        DepartmentHODSignature = Array.Empty<byte>();
        DepartmentStamp = Array.Empty<byte>();
        DepartmentWorkingHours = string.Empty;
        DepartmentPortalStatus = false;
        DepartmentPortalMessage = string.Empty;
    }
}
