using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class FormFields
{
    public Guid FormFieldsId { get; set; }

    public Guid RequestTypeFormStepId { get; set; } 
    // public virtual RequestTypeFormStep? RequestTypeFormStep { get; set; } 

    public required string Label { get; set; }

    public required InputTypesEnum InputType { get; set; }

    public required bool IsRequired { get; set; }

    public string? Placeholder { get; set; }

    public string? Width { get; set; }

    public string? FieldTips { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public ICollection<FormSelectOptions> FormSelectOptions { get; set; } = [];
    

}