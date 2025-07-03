using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class RequestType
{
    public Guid RequestTypeId { get; set; }

    public string? RoutingtoView { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Steps { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; } = "Dev";

    public string? UpdatedBy { get; set; } = "Dev";

    public ICollection<RequestTypeFormStep> RequestTypeFormStep { get; set; } = [];

   
}
