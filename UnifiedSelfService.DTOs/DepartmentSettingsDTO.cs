using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class DepartmentSettingDTO
    {
        [StringLength(50, ErrorMessage = "Color cannot exceed 50 characters.")]
        public string? Color { get; set; } = null!;

        // Assuming the logo is optional; if it should be required, add [Required]
        public byte[]? Logo { get; set; } = null!;

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }

        [StringLength(100, ErrorMessage = "Current HOD cannot exceed 100 characters.")]
        public string? CurrentHod { get; set; } = null!;

        [StringLength(500, ErrorMessage = "Thank you message cannot exceed 500 characters.")]
        public string? ThankYouMessage { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid telephone number.")]
        [StringLength(20, ErrorMessage = "Telephone cannot exceed 20 characters.")]
        public string? Telephone { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string? Email { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Working hours cannot exceed 100 characters.")]
        public string? WorkingHours { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Office cannot exceed 100 characters.")]
        public string? Office { get; set; } = null!;

        // Boolean value types are always provided, so no validation needed.
        public bool PortalStatus { get; set; }

        [StringLength(250, ErrorMessage = "Portal status message cannot exceed 250 characters.")]
        public string? PortalStatusMessage { get; set; } = null!;

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;
    }
}
