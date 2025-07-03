using System;
using System.Collections.Generic;
namespace Shared.Domain.Models;

public partial class DepartmentSetting
{
    public Guid DepartmentSettingsId { get; set; }

    public string? Color { get; set; }

    public byte[]? Logo { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string? CurrentHod { get; set; }

    public string? Office { get; set; }

    public string? ThankYouMessage { get; set; }

    public string? Telephone { get; set; }
    
    public string? Email { get; set; }

    public string? WorkingHours { get; set; }

    public bool PortalStatus { get; set; }

    public string? PortalStatusMessage { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public int? DeptId { get; set; }

    public virtual Department Department { get; set; }
}
