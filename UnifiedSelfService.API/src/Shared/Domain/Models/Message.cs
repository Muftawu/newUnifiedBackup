using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public partial class Message
{
    public Guid MessageId { get; set; }

    public string? DepartmentEmail { get; set; }

    public string? PaymentInvoice { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? UserId { get; set; }

    public Guid? DepartmentRequestTypeId { get; set; }

    public virtual DepartmentRequestType? DepartmentRequestTypeNavigation { get; set; }

    public virtual User? User { get; set; }
}
