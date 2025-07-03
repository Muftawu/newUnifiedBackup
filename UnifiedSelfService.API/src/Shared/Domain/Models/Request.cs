using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

// an instance of a request made by a user
public class Request
{
    public Guid RequestId { get; set; }
 
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public bool IsRejected { get; set; }

    public bool CanEditRequest { get; set; }

    public string? IsDeleted { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid DepartmentRequestTypeId { get; set; }

    public Guid UserId { get; set; }

    public virtual DepartmentRequestType? DepartmentRequestTypeNavigation { get; set; }

    public virtual ICollection<RequestTransaction> RequestTransactions { get; set; } = new List<RequestTransaction>();
}
