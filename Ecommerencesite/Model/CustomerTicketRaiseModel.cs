using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
          public class CustomerTicketRaiseModel
          {
                    [Key]
                    public int TicketId { get; set; }

                    // Auto Generated Ticket Number
                    public string? TicketNumber { get; set; }

                    // Customer Details
                    [Required(ErrorMessage = "Customer Name is required")]
                    public string CustomerName { get; set; } = string.Empty;

                    [Required(ErrorMessage = "Mobile Number is required")]
                    public string MobileNo { get; set; } = string.Empty;

                    [Required(ErrorMessage = "Email is required")]
                    [EmailAddress(ErrorMessage = "Invalid Email Address")]
                    public string Email { get; set; } = string.Empty;

                    // Optional Details - explicitly initialized safely
                    public string? CustomerId { get; set; } = null;
                    public string? OrderId { get; set; } = null;
                    public string? MedicineName { get; set; } = null;

                    // Issue Details
                    [Required(ErrorMessage = "Issue Category is required")]
                    public string IssueCategory { get; set; } = string.Empty;

                    [Required(ErrorMessage = "Subject is required")]
                    public string Subject { get; set; } = string.Empty;

                    [Required(ErrorMessage = "Description is required")]
                    public string Description { get; set; } = string.Empty;

                    // Priority & Status defaults
                    public string? Priority { get; set; } = "Medium";
                    public string? Status { get; set; } = "Open";

                    // Attachment (Screenshot / Prescription)
                    public string? Attachment { get; set; } = null;

                    // Admin Information
                    public string? AssignedTo { get; set; } = null;
                    public string? ResolutionRemark { get; set; } = null;

                    // Audit Fields
                    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
                    public DateTime? UpdatedDate { get; set; } = null;
                    public DateTime? ClosedDate { get; set; } = null;
          }
}