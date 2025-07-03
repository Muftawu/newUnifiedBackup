using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class DepartmentRequestPaymentChannel
{
    public Guid DepartmentRequestPaymentChannelId { get; set; }

    public Guid? DepartmentRequestTypeId { get; set; }

    public int? PaymentChannelId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; } = null!;

    public string? UpdatedBy { get; set; } = null!;
}
