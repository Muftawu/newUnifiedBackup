using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class ProgrammeRead
{
    public Guid ProgrammeReadId { get; set; }

    public string? FullNameOnCertificate { get; set; }

    public string? StudentNumber { get; set; }

    public string? IndexNumber { get; set; }

    public string? ProgrammeName { get; set; }

    public int? ProgrammeId { get; set; }

    public string? AdmissionYear { get; set; }

    public string? GraduationYear { get; set; }

    public string? ThesisTopic { get; set; }

    public string? GraduateType { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid UserId { get; set; }

}
