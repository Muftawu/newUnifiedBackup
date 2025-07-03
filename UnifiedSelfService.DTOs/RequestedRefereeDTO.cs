using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class RequestedRefereeDTO
    {
        [Required(ErrorMessage = "RefereeId is required.")]
        public Guid RefereeId { get; set; }

        public bool IsRejected { get; set; }

        [Required(ErrorMessage = "RejectedDate is required.")]
        public DateTime RejectedDate { get; set; }

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; }

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }
    }
}
