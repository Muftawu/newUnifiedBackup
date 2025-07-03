using System;
using System.Collections.Generic;

namespace Shared.Domain.Models;

public class FormSelectOptions
{
    public Guid FormSelectOptionsId { get; set; } 

    public Guid FormFieldsId { get; set; } 
    // public virtual FormFields? FormFields { get; set; }

    public string? OptionName { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }


}

