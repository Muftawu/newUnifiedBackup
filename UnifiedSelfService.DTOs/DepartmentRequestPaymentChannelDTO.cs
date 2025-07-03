using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public partial class DepartmentRequestPaymentChannelDTO
    {
        [StringLength(50, ErrorMessage = "PaymentNumber cannot exceed 50 characters.")]
        public string? PaymentNumber { get; set; } = null!;

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }

        [StringLength(100, ErrorMessage = "PaymentServiceName cannot exceed 100 characters.")]
        public string? PaymentServiceName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;
    }
}
