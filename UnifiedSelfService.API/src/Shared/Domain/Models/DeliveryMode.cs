using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class DeliveryMode
{
    public Guid DeliveryModeId { get; set; }

    public string? Mode { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
 
    public string? CreatedBy { get; set; }

    public virtual ICollection<DepartmentDeliveryMode> DepartmentDeliveryModes { get; set; } = new List<DepartmentDeliveryMode>();
}
