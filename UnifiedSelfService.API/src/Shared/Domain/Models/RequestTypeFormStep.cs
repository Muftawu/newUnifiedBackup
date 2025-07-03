namespace Shared.Domain.Models;

public class RequestTypeFormStep
{
    public Guid RequestTypeFormStepId { get; set; }

    public Guid RequestTypeId { get; set; }
    // public virtual RequestType? RequestType { get; set; }

    public required string StepNumber { get; set; }
    public string? StepDescription { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; } = "Dev";
    public string? UpdatedBy { get; set; } = "Dev";

    public ICollection<FormFields> FormFields { get; set; } = [];

   
}