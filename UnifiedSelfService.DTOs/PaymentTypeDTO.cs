using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PaymentTypeDTO
    {
        [Required(ErrorMessage = "Payment mode is required.")]
        [StringLength(100, ErrorMessage = "Payment mode cannot exceed 100 characters.")]
        public string? PaymentMode { get; set; } = null!;

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Updated date is required.")]
        public DateTime UpdatedDate { get; set; }

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;
    }
}
