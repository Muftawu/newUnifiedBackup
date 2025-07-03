using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

// request transaction class for every transaction made
// contains a verification token for in person users
public partial class RequestTransaction
{
    public Guid RequestTransactionId { get; set; }

    public string? PaymentStatus { get; set; }

    public string? ProcessingStatus { get; set; }

    // for when payment has been made
    public string? TransactionPaymentRef { get; set; }

    // transaction token for in-person users
    public string? TransactionReference { get; set; }

    public string? DeliveryModeOption { get; set;}

    public string? RecipientInfo { get; set; }

	public string? ProgrammeOfStudy { get; set; }

    public DateTime PaidDate { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid? RequestId { get; set; }

    public virtual Request? Request { get; set; }
}
