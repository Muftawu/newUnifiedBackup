using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class DepartmentSubscriptionDTO
    {   
        [Required(ErrorMessage = "A department is required.")]
        // [StringLength(200, ErrorMessage = "Department cannot exceed 200 characters.")]
        public int? SISDeptId { get; set; }

        [Required(ErrorMessage = "A request type is required.")]
        [StringLength(200, ErrorMessage = " cannot exceed 200 characters.")]
        public string? RequestTypeId { get; set; }

        [Required(ErrorMessage = "Created by is required.")]
        [StringLength(200, ErrorMessage = "Created by cannot exceed 200 characters.")]
        public string? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
