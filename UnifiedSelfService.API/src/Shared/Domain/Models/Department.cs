using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public int? FacultyId { get; set; }

    public int? CollegeId { get; set; }

    public string? DepartmentName { get; set; }

    public string? DepartmentHead { get; set; }

    public string? Phone { get; set; }

    public string? PhoneExt { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public string? Website { get; set; }

    public bool? IsActive { get; set; } = false;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<DepartmentRequestType> DepartmentRequestTypes { get; set; } = new List<DepartmentRequestType>();

    public virtual ICollection<DepartmentSetting> DepartmentSettings { get; set; } = new List<DepartmentSetting>();
}
