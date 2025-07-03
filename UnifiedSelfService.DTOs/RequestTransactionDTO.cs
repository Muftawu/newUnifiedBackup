using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class RequestTransactionDTO
    {
        [StringLength(50, ErrorMessage = "Payment status cannot exceed 50 characters.")]
        public string? PaymentStatus { get; set; }

        [StringLength(50, ErrorMessage = "Processing status cannot exceed 50 characters.")]
        public string? ProcessingStatus { get; set; }

        [StringLength(100, ErrorMessage = "Transaction payment reference cannot exceed 100 characters.")]
        public string? TransactionPaymentRef { get; set; }

        [StringLength(100, ErrorMessage = "Transaction reference cannot exceed 100 characters.")]
        public string? TransactionReference { get; set; }

        [StringLength(50, ErrorMessage = "Delivery mode option cannot exceed 50 characters.")]
        public string? DeliveryModeOption { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(20, ErrorMessage = "Recipient phone number cannot exceed 20 characters.")]
        public string? RecipientPhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "Recipient info cannot exceed 100 characters.")]
        public string? RecipientInfo { get; set; }

        [StringLength(200, ErrorMessage = "Programme of study cannot exceed 200 characters.")]
        public string? ProgrammeOfStudy { get; set; }

        [Required(ErrorMessage = "Paid date is required.")]
        public DateTime PaidDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Created date is required.")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Updated date is required.")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [StringLength(50, ErrorMessage = "CreatedBy cannot exceed 50 characters.")]
        public string? CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "UpdatedBy cannot exceed 50 characters.")]
        public string? UpdatedBy { get; set; }
    }
}
