using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class IdentificationCard
{
    public Guid IdentificationCardId { get; set; }

    public string? IdentificationCardType { get; set; }

    public string? IdentificationCardNumber { get; set; }

    public byte[]? IdentificationCardFile { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public Guid UserId { get; set; }

}