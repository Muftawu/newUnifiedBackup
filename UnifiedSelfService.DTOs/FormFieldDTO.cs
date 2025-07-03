using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs
{
    public partial class FormFieldDTO
    {
        [StringLength(50, ErrorMessage = "InputType cannot exceed 50 characters.")]
        public required string InputType { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Label cannot exceed 50 characters.")]
        public required string Label { get; set; } = null!;

        public bool IsRequired { get; set; } = false;

        [StringLength(50, ErrorMessage = "Placeholder cannot exceed 50 characters.")]
        public string? Placeholder { get; set; }

        [StringLength(50, ErrorMessage = "Width cannot exceed 50 characters.")]
        public string? Width { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;
    }
}
