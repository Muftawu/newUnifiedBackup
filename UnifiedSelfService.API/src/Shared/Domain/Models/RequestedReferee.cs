using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public partial class RequestedReferee
{
    public Guid RequestedRefereeId { get; set; }

    public string? RefereeId { get; set; }

    public string? RecommendationId { get; set; }

    public bool IsRejected { get; set; }

    public DateTime RejectedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

}
