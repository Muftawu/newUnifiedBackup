using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class RequestTypeDTO
    {
        [StringLength(200, ErrorMessage = "RoutingtoView cannot exceed 200 characters.")]
        public string? RoutingtoView { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [StringLength(1, ErrorMessage = "Name cannot exceed a characters.")]
        public string? Steps { get; set; }

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = "Dev";

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = "Dev";
    }
}
