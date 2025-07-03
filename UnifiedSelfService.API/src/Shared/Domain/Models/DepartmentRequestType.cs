using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public partial class DepartmentRequestType
{
    public Guid DepartmentRequestTypeId { get; set; }

    public bool AcceptPayment { get; set; }

    public decimal Amount { get; set; }
    
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string? UpdatedBy { get; set; }

    public string? CreatedBy { get; set; } 

    public int? SISDeptId { get; set; } 

    public Guid RequestTypeId { get; set; }

    public virtual ICollection<DepartmentDeliveryMode> DepartmentDeliveryModes { get; set; } = new List<DepartmentDeliveryMode>();

    public virtual ICollection<DepartmentRequestPaymentChannel> DepartmentRequestPaymentChannel { get; set; } = new List<DepartmentRequestPaymentChannel>();

    public virtual RequestType? RequestType { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

}
