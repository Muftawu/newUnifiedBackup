using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public partial class DepartmentDeliveryMode
{
    public Guid DepartmentDeliveryModeId { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public Guid? DepartmentRequestTypeId { get; set; }

    public Guid? DeliveryModeId { get; set; } 

    public virtual DeliveryMode? DeliveryMode { get; set; }

    public virtual DepartmentRequestType? DepartmentRequestTypeNavigation { get; set; }
}
