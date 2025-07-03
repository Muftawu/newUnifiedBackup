using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public partial class DepartmentDeliveryModeDTO
    {
        [Required(ErrorMessage = "CreatedBy is required.")]
        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;

        [Required(ErrorMessage = "UpdatedBy is required.")]
        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        
        public DateTime? UpdatedDate { get; set; }

        [Required(ErrorMessage = "DepartmentRequestType is required.")]
        [StringLength(100, ErrorMessage = "DepartmentRequestType cannot exceed 100 characters.")]
        public string? DepartmentRequestType { get; set; } = null!;
    }
}
