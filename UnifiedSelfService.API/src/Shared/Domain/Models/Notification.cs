using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public partial class Notification
{
    public Guid NotificationId { get; set; }

    public Guid? SubscribedDepartmentId { get; set; }

    public string? NotificationName { get; set; }

    public string? NotificationContent { get; set; }

    // link to take to users to application
    public string? NotficationLink { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual DepartmentRequestType? DepartmentRequestTypeNavigation { get; set; }

    public virtual User? User { get; set; }
}
