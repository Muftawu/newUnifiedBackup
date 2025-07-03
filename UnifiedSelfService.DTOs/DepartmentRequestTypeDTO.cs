using System;
using System.ComponentModel.DataAnnotations;
using Shared.Domain.Models;

namespace DTOs
{
    public class DepartmentRequestTypeDTO
    {
        // Since AcceptPayment is a value type (bool), it's always provided.
        public bool AcceptPayment { get; set; }

        // Amount must be non-negative
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Amount must be non-negative.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "UpdatedDate is required.")]
        public DateTime UpdatedDate { get; set; }

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; } = null!;

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; } = null!;
    }

    public class UserDepartmentsDTO
    {
        public List<int> userDepartmentIds { get; set; }
    }

    public class DepartmentSubscriptionDisplayModel
    {
        public DepartmentRequestType DeptSubscription{ get; set; }
        public string DepartmentName { get; set; }
    }
    
    public class DepartmentDisplayModel
    {
        public Department Department { get; set; }
        public string FacultyName { get; set; }
        public string CollegeName { get; set; }
    }

    public class RequestTypeDisplayModel 
    {
        public RequestType RequestType { get; set; }
    }

}

