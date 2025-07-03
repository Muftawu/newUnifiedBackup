using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTOs
{
    public class DepartmentDTO
    {
        [Required(ErrorMessage = "DepartmentName is required.")]
        [StringLength(100, ErrorMessage = "DepartmentName cannot exceed 100 characters.")]
        public string? DepartmentName { get; set; } = null!;

        [StringLength(100, ErrorMessage = "DepartmentHead cannot exceed 100 characters.")]
        public string? DepartmentHead { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Phone cannot exceed 100 characters.")]
        public string? Phone { get; set; } = null!;
        
        [StringLength(100, ErrorMessage = "PhoneExt cannot exceed 100 characters.")]
        public string? PhoneExt { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string? Email { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Fax cannot exceed 100 characters.")]
        public string? Fax { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Website cannot exceed 100 characters.")]
        public string? Website { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;
    }

    public class DepartmentSubscriptionRequestDTO
    {
        [JsonPropertyName("departmentDTO")]
        public DepartmentDTO DepartmentDTO { get; set; }
        
        [JsonPropertyName("generateCredential")]
        public bool generateCredential { get; set; }

        [JsonPropertyName("adminEmail")]
        public string adminEmail { get; set; }


    }
}
