using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class Programme
{
    public int ProgrammeId { get; set; }

    public string? Name { get; set; }
    
    public string? AwardName { get; set; }
    
    public int? GraduateTypeId { get; set; }

    public int? CertificateTypeId { get; set; }
    
    public string? ShortCode { get; set; }

    public string? ShortName{ get; set; }
    
    public int? AcademicGroupId { get; set; }

    public string? Overview { get; set; }

    public string? CourseContent { get; set; }

    public string? Requirement { get; set; }

    public string? Career { get; set; }

    public string? TimeInserted { get; set; }

    public string? InsertedBy{ get; set; }

    public string? LongProgrammeName { get; set; }

    public int? DegreeId { get; set; }

}
