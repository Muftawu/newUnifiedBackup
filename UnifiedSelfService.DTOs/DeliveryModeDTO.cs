using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class DeliveryModeDTO
    {
        [Required(ErrorMessage = "Mode is required.")]
        [StringLength(100, ErrorMessage = "Mode cannot exceed 100 characters.")]
        public string? Mode { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Updated date is required.")]
        public DateTime UpdatedDate { get; set; }

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; }

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; }
    }
}
