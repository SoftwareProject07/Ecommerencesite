using System;
using System.ComponentModel.DataAnnotations;

namespace HelpDeskAPI.Models
{
          public class CustomerTicketRaiseModel
          {
                    [Key]
                    public int TicketId { get; set; }

                    // Auto Generated Ticket Number
                    public string TicketNumber { get; set; }

                    // Customer Details
                    [Required]
                    public string CustomerName { get; set; }

                    [Required]
                    public string MobileNo { get; set; }

                    [Required]
                    [EmailAddress]
                    public string Email { get; set; }

                    // Optional Details
                    public string CustomerId { get; set; }

                    public string OrderId { get; set; }

                    public string MedicineName { get; set; }

                    // Issue Details
                    [Required]
                    public string IssueCategory { get; set; }
                    // Technical Issue
                    // Login Issue
                    // Payment Issue
                    // Order Issue
                    // Medicine Search Issue
                    // Prescription Upload Issue
                    // Delivery Issue
                    // Refund Issue
                    // Other

                    [Required]
                    public string Subject { get; set; }

                    [Required]
                    public string Description { get; set; }

                    // Priority
                    public string Priority { get; set; } = "Medium";
                    // Low
                    // Medium
                    // High
                    // Critical

                    // Ticket Status
                    public string Status { get; set; } = "Open";
                    // Open
                    // Assigned
                    // In Progress
                    // Pending
                    // Resolved
                    // Closed

                    // Attachment (Screenshot / Prescription)
                    public string Attachment { get; set; }

                    // Admin Information
                    public string AssignedTo { get; set; }

                    public string ResolutionRemark { get; set; }

                    // Audit Fields
                    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

                    public DateTime? UpdatedDate { get; set; }

                    public DateTime? ClosedDate { get; set; }
          }
}