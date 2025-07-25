using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs;

public partial class FormSelectOptionDTO
{
    public string OptionName { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }
}
